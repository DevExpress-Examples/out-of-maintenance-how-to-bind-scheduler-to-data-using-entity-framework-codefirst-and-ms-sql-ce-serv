Imports Microsoft.VisualBasic
Imports System.Data.Entity

Namespace DevExpressMvcSchedulerEF.Views
	Public Class SchedulerContext
		Inherits DbContext
		Private privateEFAppointments As DbSet(Of EFAppointment)
		Public Property EFAppointments() As DbSet(Of EFAppointment)
			Get
				Return privateEFAppointments
			End Get
			Set(ByVal value As DbSet(Of EFAppointment))
				privateEFAppointments = value
			End Set
		End Property
		Private privateEFResources As DbSet(Of EFResource)
		Public Property EFResources() As DbSet(Of EFResource)
			Get
				Return privateEFResources
			End Get
			Set(ByVal value As DbSet(Of EFResource))
				privateEFResources = value
			End Set
		End Property
	End Class

  Friend Class SchedulerContextSeedInilializer
	  Inherits DropCreateDatabaseIfModelChanges(Of SchedulerContext)
		Protected Overrides Sub Seed(ByVal context As SchedulerContext)
			Dim res1 As New EFResource()
			res1.ResourceID = 1
			res1.ResourceName = "Resource1"
			context.EFResources.Add(res1)
			res1.Color = System.Drawing.Color.DarkOrange.ToArgb()

			Dim res2 As New EFResource()
			res2.ResourceID = 2
			res2.ResourceName = "Resource2"
			res2.Color = System.Drawing.Color.SteelBlue.ToArgb()
			context.EFResources.Add(res2)

			MyBase.Seed(context)
		End Sub

  End Class
End Namespace
