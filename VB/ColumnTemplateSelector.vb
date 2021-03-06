﻿Imports System.Windows.Controls
Imports System.Windows
Imports Model


Namespace View
	Public Class ColumnTemplateSelector
		Inherits DataTemplateSelector

		Public Overrides Function SelectTemplate(ByVal item As Object, ByVal container As DependencyObject) As DataTemplate
			Dim column As Column = DirectCast(item, Column)
			Return DirectCast(CType(container, Control).FindResource(column.Settings.ToString() & "ColumnTemplate"), DataTemplate)
		End Function
	End Class
End Namespace