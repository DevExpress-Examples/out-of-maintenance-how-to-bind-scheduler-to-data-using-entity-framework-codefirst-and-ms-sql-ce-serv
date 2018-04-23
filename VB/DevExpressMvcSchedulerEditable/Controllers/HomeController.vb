Imports Microsoft.VisualBasic
Imports System.Web.Mvc
Imports DevExpress.Web.Mvc

Namespace DevExpressMvcSchedulerEF.View
	Public Class HomeController
		Inherits Controller
		'
		' GET: /Home/

Public Function Index() As ActionResult
	Return View(SchedulerDataHelper.DataObject)
End Function

		Public Function SchedulerPartial() As ActionResult
			Return PartialView("SchedulerPartial", SchedulerDataHelper.DataObject)
		End Function

		Public Function EditAppointment() As ActionResult
			UpdateAppointment()
			Return PartialView("SchedulerPartial", SchedulerDataHelper.DataObject)
		End Function
		#Region "#updateappointment"
		Private Shared Sub UpdateAppointment()
	Dim insertedAppt As EFAppointment = SchedulerExtension.GetAppointmentToInsert(Of EFAppointment)(SchedulerSettingsHelper.CommonSchedulerSettings, SchedulerDataHelper.GetAppointments(), SchedulerDataHelper.GetResources())
	SchedulerDataHelper.InsertAppointment(insertedAppt)

	Dim updatedAppt() As EFAppointment = SchedulerExtension.GetAppointmentsToUpdate(Of EFAppointment)(SchedulerSettingsHelper.CommonSchedulerSettings, SchedulerDataHelper.GetAppointments(), SchedulerDataHelper.GetResources())
	For Each appt In updatedAppt
		SchedulerDataHelper.UpdateAppointment(appt)
	Next appt

	Dim removedAppt() As EFAppointment = SchedulerExtension.GetAppointmentsToRemove(Of EFAppointment)(SchedulerSettingsHelper.CommonSchedulerSettings, SchedulerDataHelper.GetAppointments(), SchedulerDataHelper.GetResources())
	For Each appt In removedAppt
		SchedulerDataHelper.RemoveAppointment(appt)
	Next appt

		End Sub
		#End Region ' #updateappointment

	End Class
End Namespace
