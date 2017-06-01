Imports System.IO
Imports System.Data.OleDb
Imports System.Security


Public Class Form1

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim db As New OleDbConnection

        db.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\ProgramData\locker\locklog.accdb;Persist Security Info=True;Jet OLEDB:Database Password=test"
        db.Open()
        Dim cm As New OleDbCommand


        Dim dd As OleDbDataReader

        Dim ds As New DataTable

        ds.Clear()
        cm.Connection = db
        cm.CommandText = "select passwd from locklog"
        dd = cm.ExecuteReader
        ds.Load(dd)



        Dim r() As DataRow = ds.Select
        If TextBox1.Text = r(0).Item("passwd") Then
            Form3.Show()
        Else
            MessageBox.Show("wrong password")





        End If
        db.Close()


    End Sub

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
      
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.Hide()
        Form2.Show()

    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Me.Hide()
        Form5.Show()

    End Sub

    Private Sub Label3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub
End Class
