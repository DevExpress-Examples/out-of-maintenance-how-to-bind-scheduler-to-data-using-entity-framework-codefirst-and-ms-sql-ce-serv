Imports Microsoft.VisualBasic
Imports System
Imports System.ComponentModel.DataAnnotations

Namespace DevExpressMvcSchedulerEF
	Public Class EFAppointment
		Private privateUniqueID As Integer
		<Key()> _
		Public Property UniqueID() As Integer
			Get
				Return privateUniqueID
			End Get
			Set(ByVal value As Integer)
				privateUniqueID = value
			End Set
		End Property
		Private privateType As Integer
		<Required> _
		Public Property Type() As Integer
			Get
				Return privateType
			End Get
			Set(ByVal value As Integer)
				privateType = value
			End Set
		End Property
		Private privateStartDate As DateTime
		<Required> _
		Public Property StartDate() As DateTime
			Get
				Return privateStartDate
			End Get
			Set(ByVal value As DateTime)
				privateStartDate = value
			End Set
		End Property
		Private privateEndDate As DateTime
		<Required> _
		Public Property EndDate() As DateTime
			Get
				Return privateEndDate
			End Get
			Set(ByVal value As DateTime)
				privateEndDate = value
			End Set
		End Property
		Private privateAllDay As Boolean
		Public Property AllDay() As Boolean
			Get
				Return privateAllDay
			End Get
			Set(ByVal value As Boolean)
				privateAllDay = value
			End Set
		End Property
		Private privateSubject As String
		Public Property Subject() As String
			Get
				Return privateSubject
			End Get
			Set(ByVal value As String)
				privateSubject = value
			End Set
		End Property
		Private privateLocation As String
		Public Property Location() As String
			Get
				Return privateLocation
			End Get
			Set(ByVal value As String)
				privateLocation = value
			End Set
		End Property
		Private privateDescription As String
		Public Property Description() As String
			Get
				Return privateDescription
			End Get
			Set(ByVal value As String)
				privateDescription = value
			End Set
		End Property
		Private privateStatus As Integer
		Public Property Status() As Integer
			Get
				Return privateStatus
			End Get
			Set(ByVal value As Integer)
				privateStatus = value
			End Set
		End Property
		Private privateLabel As Integer
		Public Property Label() As Integer
			Get
				Return privateLabel
			End Get
			Set(ByVal value As Integer)
				privateLabel = value
			End Set
		End Property
		Private privateResourceIDs As String
		Public Property ResourceIDs() As String
			Get
				Return privateResourceIDs
			End Get
			Set(ByVal value As String)
				privateResourceIDs = value
			End Set
		End Property
		Private privateReminderInfo As String
		Public Property ReminderInfo() As String
			Get
				Return privateReminderInfo
			End Get
			Set(ByVal value As String)
				privateReminderInfo = value
			End Set
		End Property
		Private privateRecurrenceInfo As String
		Public Property RecurrenceInfo() As String
			Get
				Return privateRecurrenceInfo
			End Get
			Set(ByVal value As String)
				privateRecurrenceInfo = value
			End Set
		End Property
	End Class
End Namespace
