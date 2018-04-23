Imports Microsoft.VisualBasic
Imports System
Imports System.ComponentModel.DataAnnotations
Imports System.Drawing

Namespace DevExpressMvcSchedulerEF
	Public Class EFResource
		Private privateUniqueID As Integer
		<Key(), DatabaseGenerated(DatabaseGeneratedOption.Identity)> _
		Public Property UniqueID() As Integer
			Get
				Return privateUniqueID
			End Get
			Set(ByVal value As Integer)
				privateUniqueID = value
			End Set
		End Property
		Private privateResourceID As Integer
		Public Property ResourceID() As Integer
			Get
				Return privateResourceID
			End Get
			Set(ByVal value As Integer)
				privateResourceID = value
			End Set
		End Property
		Private privateResourceName As String
		Public Property ResourceName() As String
			Get
				Return privateResourceName
			End Get
			Set(ByVal value As String)
				privateResourceName = value
			End Set
		End Property
		Private privateImage As Byte()
		Public Property Image() As Byte()
			Get
				Return privateImage
			End Get
			Set(ByVal value As Byte())
				privateImage = value
			End Set
		End Property
		<NotMapped> _
		Public Property Color() As Integer
			Get
				Return ColorEx.ToArgb()
			End Get
			Set(ByVal value As Integer)
				ColorEx = New MyColor(value)
			End Set
		End Property
		Private privateColorEx As MyColor
		Public Property ColorEx() As MyColor
			Get
				Return privateColorEx
			End Get
			Set(ByVal value As MyColor)
				privateColorEx = value
			End Set
		End Property

	End Class

	<ComplexType> _
	Public Class MyColor
		Private privateA As Byte
		Public Property A() As Byte
			Get
				Return privateA
			End Get
			Set(ByVal value As Byte)
				privateA = value
			End Set
		End Property
		Private privateR As Byte
		Public Property R() As Byte
			Get
				Return privateR
			End Get
			Set(ByVal value As Byte)
				privateR = value
			End Set
		End Property
		Private privateG As Byte
		Public Property G() As Byte
			Get
				Return privateG
			End Get
			Set(ByVal value As Byte)
				privateG = value
			End Set
		End Property
		Private privateB As Byte
		Public Property B() As Byte
			Get
				Return privateB
			End Get
			Set(ByVal value As Byte)
				privateB = value
			End Set
		End Property

		Public Sub New()
		End Sub
		Public Sub New(ByVal a As Byte, ByVal r As Byte, ByVal g As Byte, ByVal b As Byte)
			A = a
			R = r
			G = g
			B = b
		End Sub
		Public Sub New(ByVal color As Color)
			A = color.A
			R = color.R
			G = color.G
			B = color.B
		End Sub
		Public Sub New(ByVal argb As Integer)
			Dim bytes() As Byte = BitConverter.GetBytes(argb)
			A = bytes(0)
			R = bytes(1)
			G = bytes(2)
			B = bytes(3)
		End Sub

		Public Function ToColor() As Color
			Return Color.FromArgb(A, R, G, B)
		End Function
		Public Shared Function FromColor(ByVal color As Color) As MyColor
			Return New MyColor(color.A, color.R, color.G, color.B)
		End Function
		Public Function ToArgb() As Integer
			Dim bytes() As Byte = { A, R, G, B }
			Return BitConverter.ToInt32(bytes, 0)
		End Function

	End Class

End Namespace
