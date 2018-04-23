Imports Microsoft.VisualBasic
Imports System.Collections
Imports System.Linq
Imports DevExpress.Web.Mvc
Imports DevExpressMvcSchedulerEF.Views

Namespace DevExpressMvcSchedulerEF
	Public Class SchedulerDataObject
		Private privateAppointments As IEnumerable
		Public Property Appointments() As IEnumerable
			Get
				Return privateAppointments
			End Get
			Set(ByVal value As IEnumerable)
				privateAppointments = value
			End Set
		End Property
		Private privateResources As IEnumerable
		Public Property Resources() As IEnumerable
			Get
				Return privateResources
			End Get
			Set(ByVal value As IEnumerable)
				privateResources = value
			End Set
		End Property
	End Class

	Public Class SchedulerDataHelper
		Public Shared Function GetResources() As IEnumerable
			Return SchedulerSettingsHelper.LocalContext.EFResources.Local
		End Function
		Public Shared Function GetAppointments() As IEnumerable
			Return SchedulerSettingsHelper.LocalContext.EFAppointments.Local
		End Function
		Public Shared ReadOnly Property DataObject() As SchedulerDataObject
			 Get
				 Dim sdo As New SchedulerDataObject()
				sdo.Appointments = GetAppointments()
				 sdo.Resources = GetResources()
				Return sdo
			 End Get
		End Property

		Private Shared defaultAppointmentStorage_Renamed As MVCxAppointmentStorage
		Public Shared ReadOnly Property DefaultAppointmentStorage() As MVCxAppointmentStorage
			Get
				If defaultAppointmentStorage_Renamed Is Nothing Then
					defaultAppointmentStorage_Renamed = CreateDefaultAppointmentStorage()
				End If
				Return defaultAppointmentStorage_Renamed
			End Get
		End Property

		Private Shared Function CreateDefaultAppointmentStorage() As MVCxAppointmentStorage
			Dim appointmentStorage As New MVCxAppointmentStorage()
			appointmentStorage.Mappings.AppointmentId = "UniqueID"
			appointmentStorage.Mappings.Start = "StartDate"
			appointmentStorage.Mappings.End = "EndDate"
			appointmentStorage.Mappings.Subject = "Subject"
			appointmentStorage.Mappings.Description = "Description"
			appointmentStorage.Mappings.Location = "Location"
			appointmentStorage.Mappings.AllDay = "AllDay"
			appointmentStorage.Mappings.Type = "Type"
			appointmentStorage.Mappings.RecurrenceInfo = "RecurrenceInfo"
			appointmentStorage.Mappings.ReminderInfo = "ReminderInfo"
			appointmentStorage.Mappings.Label = "Label"
			appointmentStorage.Mappings.Status = "Status"
			appointmentStorage.Mappings.ResourceId = "ResourceIDs"
			Return appointmentStorage
		End Function

		Private Shared defaultResourceStorage_Renamed As MVCxResourceStorage
		Public Shared ReadOnly Property DefaultResourceStorage() As MVCxResourceStorage
			Get
				If defaultResourceStorage_Renamed Is Nothing Then
					defaultResourceStorage_Renamed = CreateDefaultResourceStorage()
				End If
				Return defaultResourceStorage_Renamed
			End Get
		End Property
		Private Shared Function CreateDefaultResourceStorage() As MVCxResourceStorage
			Dim resourceStorage As New MVCxResourceStorage()
			resourceStorage.Mappings.ResourceId = "ResourceID"
			resourceStorage.Mappings.Caption = "ResourceName"
			resourceStorage.Mappings.Color = "Color"
			Return resourceStorage
		End Function

		Public Shared Sub InsertAppointment(ByVal appt As EFAppointment)
			If appt Is Nothing Then
				Return
			End If
			Dim db As SchedulerContext = SchedulerSettingsHelper.LocalContext
			db.EFAppointments.Local.Add(appt)
			db.SaveChanges()
		End Sub
		Public Shared Sub UpdateAppointment(ByVal appt As EFAppointment)
			If appt Is Nothing Then
				Return
			End If
			Dim db As SchedulerContext = SchedulerSettingsHelper.LocalContext
			Dim query As EFAppointment = CType(( _
						From carSchedule In db.EFAppointments.Local _
						Where carSchedule.UniqueID = appt.UniqueID _
						Select carSchedule).SingleOrDefault(), EFAppointment)

			query.UniqueID = appt.UniqueID
			query.StartDate = appt.StartDate
			query.EndDate = appt.EndDate
			query.AllDay = appt.AllDay
			query.Subject = appt.Subject
			query.Description = appt.Description
			query.Location = appt.Location
			query.RecurrenceInfo = appt.RecurrenceInfo
			query.ReminderInfo = appt.ReminderInfo
			query.Status = appt.Status
			query.Type = appt.Type
			query.Label = appt.Label
			query.ResourceIDs = appt.ResourceIDs
			db.SaveChanges()
		End Sub
		Public Shared Sub RemoveAppointment(ByVal appt As EFAppointment)
			If appt Is Nothing Then
				Return
			End If
			Dim db As SchedulerContext = SchedulerSettingsHelper.LocalContext
			Dim query As EFAppointment = CType(( _
						From carSchedule In db.EFAppointments.Local _
						Where carSchedule.UniqueID = appt.UniqueID _
						Select carSchedule).SingleOrDefault(), EFAppointment)
			db.EFAppointments.Remove(query)
			db.SaveChanges()
		End Sub
	End Class
End Namespace