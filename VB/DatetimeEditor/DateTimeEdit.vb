Imports DevExpress.Xpf.Editors
Imports DevExpress.Xpf.Editors.Popups.Calendar
Imports DevExpress.Xpf.Editors.Services
Imports DevExpress.Xpf.Editors.Validation.Native
Imports System
Imports System.Linq

Namespace DatetimeEditor
	Public Class DateTimeEditCalendar
		Inherits DateEditCalendar

		Protected Overrides Sub OnDateTimeChanged()
			MyBase.OnDateTimeChanged()
            Time = Me.DateTime
        End Sub
		Public Shared TimeProperty As DependencyProperty = DependencyProperty.Register("Time", GetType(Date), GetType(DateTimeEditCalendar), New PropertyMetadata(New Date(), New PropertyChangedCallback(Sub(obj, e)
			Dim calendar = CType(obj, DateTimeEditCalendar)
			calendar.PostDateTimeToEditValue(calendar.CombineDateTime(calendar.DateTime, CDate(e.NewValue)))
		End Sub)))
		Private Sub PostDateTimeToEditValue(ByVal dt As Date)
			ActualPropertyProvider.GetProperties(OwnerDateEdit).GetService(Of ValueContainerService)().SetEditValue(dt, UpdateEditorSource.ValueChanging)
		End Sub
		Private Function CombineDateTime(ByVal [date] As Date, ByVal time As Date) As Date
			Return New Date([date].Year, [date].Month, [date].Day, time.Hour, time.Minute, time.Second, time.Millisecond)
		End Function
		Public Property Time() As Date
			Get
				Return CDate(GetValue(TimeProperty))
			End Get
			Set(ByVal value As Date)
				SetValue(TimeProperty, value)
			End Set
		End Property
        Protected Overrides Sub OnDayCellButtonClick(ByVal button As System.Windows.Controls.Button)
            If OwnerDateEdit Is Nothing Then
                If button IsNot Nothing Then
                    DateTime = (CDate(DateEditCalendar.GetDateTime(button)))
                End If
                Return
            End If
            If Not OwnerDateEdit.IsReadOnly Then
                Dim newDate = CDate(DateEditCalendar.GetDateTime(button))
                PostDateTimeToEditValue(CombineDateTime(newDate, Time))
            End If
            OwnerDateEdit.IsPopupOpen = False
        End Sub
    End Class
End Namespace