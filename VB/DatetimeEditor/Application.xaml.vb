' Developer Express Code Central Example:
' How to edit time with DateEdit in Vista mode
' 
' To make editing the time into DateEdit, perform these steps:
' 
' Create a
' DateEditCalendar descendant class, override its OnDayCellButtonClick method and
' add the Time property of the DateTime type;
' 
' Into the OnDayCellButtonClick
' method, call the base method and after this, recreate OwnerDateEdit’s DateTime
' property with the time from the Time property; To add custom content into the
' popup, use the DateEdit’s PopupContentTemplate property.
' 
' You can find sample updates and versions for different programming languages here:
' http://www.devexpress.com/example=T159077

Imports System
Imports System.Collections.Generic
Imports System.Configuration
Imports System.Data
Imports System.Linq
Imports System.Threading.Tasks
Imports System.Windows

Namespace DatetimeEditor
	''' <summary>
	''' Interaction logic for App.xaml
	''' </summary>
	Partial Public Class App
		Inherits Application

	End Class
End Namespace
