﻿Imports DevExpress.Xpf.Grid
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports System.Windows
Imports System.Windows.Data

Namespace WPFGridMVVMBindableColumns
	Public Module BindingHelper
		Public Function GetPath(ByVal obj As GridColumn) As String
			Return CStr(obj.GetValue(PathProperty))
		End Function
		Public Sub SetPath(ByVal obj As GridColumn, ByVal value As String)
			obj.SetValue(PathProperty, value)
		End Sub
		' Using a DependencyProperty as the backing store for Path.  This enables animation, styling, binding, etc...
		Public ReadOnly PathProperty As DependencyProperty = DependencyProperty.RegisterAttached("Path", GetType(String), GetType(BindingHelper), New PropertyMetadata(Sub(d, e)
			If Not String.IsNullOrWhiteSpace(TryCast(e.NewValue, String)) Then
				CType(d, GridColumn).Binding = New Binding("RowData.Row." & e.NewValue) With {.Mode = BindingMode.TwoWay}
			End If
		End Sub))
	End Module
End Namespace
