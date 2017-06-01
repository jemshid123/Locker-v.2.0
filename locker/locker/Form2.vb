Imports System.IO
Imports System.Data.OleDb


Public Class Form2

    Private Sub TextBox1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub
    Private Sub Label2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim db As New OleDbConnection

        db.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\ProgramData\locker\locklog.accdb;Persist Security Info=True;Jet OLEDB:Database Password=test"
        db.Open()
        Dim cm As New OleDbCommand


        Dim dd As OleDbDataReader

        Dim ds As New DataTable

        ds.Clear()
        cm.Connection = db

        cm = New OleDbCommand("select passwd from locklog", db)
        dd = cm.ExecuteReader()
        ds.Load(dd)
        Dim dr() As DataRow = ds.Select()
        If TextBox2.Text = TextBox3.Text Then

            If dr(0).Item(0).ToString = TextBox1.Text Then
                Dim s As String
              


                s = "update  locklog set passwd='" & TextBox2.Text & "' where passwd='" & TextBox1.Text & "'"


                cm.CommandText = s

                cm.ExecuteNonQuery()
               

                MsgBox("password changed to:" & TextBox2.Text)
                Me.Close()
                Form1.Show()
            Else
                MsgBox("password dont match")




            End If

        End If

        db.Close()











    End Sub

    Private Sub Form2_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub
End Class