Imports System
Imports System.Linq
Imports System.Windows
Imports System.Windows.Controls

Namespace DatetimeEditor
	Partial Public Class Clock
		Inherits UserControl

		Public Sub New()
			InitializeComponent()
			DataContext = Me
		End Sub
		Public Shared ReadOnly DateTimeValueProperty As DependencyProperty = DependencyProperty.Register("DateTimeValue", GetType(Date), GetType(Clock), New PropertyMetadata(Date.Now, New PropertyChangedCallback(AddressOf OnDateTimeValuePropertyChanged)))
		Public Property DateTimeValue() As Date
			Get
				Return DirectCast(GetValue(DateTimeValueProperty), Date)
			End Get
			Set(ByVal value As Date)
				SetValue(DateTimeValueProperty, value)
			End Set
		End Property
		Private Shared Sub OnDateTimeValuePropertyChanged(ByVal d As DependencyObject, ByVal e As DependencyPropertyChangedEventArgs)
			OnDateTimeValuePropertyChanged(d, e.NewValue, e.OldValue)
		End Sub
		Private Shared Sub OnDateTimeValuePropertyChanged(ByVal d As DependencyObject, ByVal p1 As Object, ByVal p2 As Object)
			Dim sender As Clock = TryCast(d, Clock)
			Dim minutes As Double = CDbl(sender.DateTimeValue.Minute)
			Dim seconds As Double = CDbl(sender.DateTimeValue.Second)
			sender.a_hour.Value = (sender.DateTimeValue.Hour) Mod 12 + minutes / 60.0
			sender.a_minute.Value = ((sender.DateTimeValue.Minute + seconds / 60.0) / 60.0) * 12
			sender.a_second.Value = (seconds / 60.0) * 12
		End Sub
	End Class
End Namespace
