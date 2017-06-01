Imports System.IO
Imports System.Data.OleDb
Imports EncryptS










Public Class Form3

    Function san(ByVal a As String) As String
        Dim tok(), tem As String
        tok = Split(a, "\")
        tem = " "
        Dim count As Int16 = 0
        While count < tok.Length - 1
            tem = tem & tok(count) & "/"
            count = count + 1
        End While
        tem = tem & tok(count)
        Return tem
    End Function

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim path As String
        Dim file As OpenFileDialog
        file = New OpenFileDialog
        file.ValidateNames = False
        file.CheckFileExists = False
        file.CheckPathExists = False
        If (file.ShowDialog = DialogResult.OK) Then
            path = file.FileName
            TextBox1.Text = path
        End If
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click

        Dim db As New OleDbConnection
        Dim cm As New OleDbCommand
        ' Try
        Dim path As String
        Dim count As Int32 = 0

        path = TextBox1.Text






        If (path <> vbNullString) Then
            db.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\ProgramData\locker\locklog.accdb;Persist Security Info=True;Jet OLEDB:Database Password=test"
            db.Open()


           
            ProgressBar1.Minimum = 0
            ProgressBar1.Maximum = 5

           
            path = TextBox1.Text
            ProgressBar1.Value = 2
            Threading.Thread.Sleep(400)
            ProgressBar1.Value = 4
            path = san(path)

            CheckedListBox1.Items.Add(path)
            cm.CommandText = "insert into dat(file) values('" & path & "')"
            cm.Connection = db
            cm.ExecuteNonQuery()
            Shell("attrib +s +h " & path)
            Threading.Thread.Sleep(400)
            ProgressBar1.Value = 5
            MsgBox("file/folder  hidden")
            Threading.Thread.Sleep(400)
            ProgressBar1.Value = 0
            TextBox1.Clear()
            FileClose(1)
            db.Close()



           
        End If
        'Catch
        'MsgBox("error")

        'End Try








    End Sub



    Private Sub Form3_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Form1.Hide()


        Dim db As New OleDbConnection
        db.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\ProgramData\locker\locklog.accdb;Persist Security Info=True;Jet OLEDB:Database Password=test"
        db.Open()
        Dim cm As New OleDbCommand


        Dim dd As OleDbDataReader

        Dim ds As New DataTable

        ds.Clear()
        cm.Connection = db

        cm = New OleDbCommand("select file from dat", db)
        dd = cm.ExecuteReader()
        ds.Load(dd)
        Dim dr() As DataRow = ds.Select()
        Dim i As Int64
        i = 0
        While i < dr.Count
            CheckedListBox1.Items.Add(dr(i).Item("file"))
            i = i + 1

        End While
        db.Close()


    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        Dim db As New OleDbConnection

        db.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\ProgramData\locker\locklog.accdb;Persist Security Info=True;Jet OLEDB:Database Password=test"
        db.Open()
        Dim cm As New OleDbCommand

        cm.Connection = db
        Dim con As Integer = 0
        con = CheckedListBox1.CheckedItems.Count

        Dim t As Integer = con
        Dim count As Integer = 0
        Dim tem, path As String
        ProgressBar1.Minimum = 0
        ProgressBar1.Maximum = t
        While (t > 0)
            tem = CheckedListBox1.CheckedItems(t - 1)
            path = tem
            path = san(path)
            Threading.Thread.Sleep(200)
            CheckedListBox1.Items.Remove(path)
           
            ProgressBar1.Value += 1



            Dim s As String = "attrib -s -h " & tem
            MsgBox(s)
            Shell(s)
            t = t - 1
        End While
        t = con
        While (t > 0)

            cm.CommandText = "delete from dat where file ='" & CheckedListBox1.CheckedItems(t - 1) & "'"
            cm.ExecuteNonQuery()

            CheckedListBox1.Items.Remove(CheckedListBox1.CheckedItems(t - 1))
            t = t - 1
        End While
        MsgBox("file unhidded")
        ProgressBar1.Value = 0
        db.Close()


    End Sub

    Private Sub SplitContainer1_Panel2_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles SplitContainer1.Panel2.Paint

    End Sub

    Private Sub GroupBox3_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GroupBox3.Enter

    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Dim db As New OleDbConnection

        db.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\ProgramData\locker\locklog.accdb;Persist Security Info=True;Jet OLEDB:Database Password=test"
        db.Open()
        Dim cm As New OleDbCommand

        cm.Connection = db
        Dim con As Integer = 0
        con = CheckedListBox1.CheckedItems.Count

        Dim t As Integer = con
        Dim tem As String
        While (t > 0)
            tem = CheckedListBox1.CheckedItems(t - 1)

            Dim s As String = "attrib -s -h " & tem
            Shell(s)
            t = t - 1
        End While
        t = con

        While (t > 0)
            If File.Exists(CheckedListBox1.CheckedItems(t - 1)) Then
                File.Delete(CheckedListBox1.CheckedItems(t - 1))
            ElseIf Directory.Exists(CheckedListBox1.CheckedItems(t - 1)) Then
                Directory.Delete(CheckedListBox1.CheckedItems(t - 1))
            End If

            cm.CommandText = "delete from dat where file ='" & CheckedListBox1.CheckedItems(t - 1) & "'"
            cm.ExecuteNonQuery()

            CheckedListBox1.Items.Remove(CheckedListBox1.CheckedItems(t - 1))
            t = t - 1
        End While

        db.Close()
    End Sub

    Private Sub Label1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label1.Click

    End Sub

    Private Sub folder_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles folder.Click
        Dim FolderBrowserDialog1 As New FolderBrowserDialog

        If FolderBrowserDialog1.ShowDialog() = DialogResult.OK Then
            TextBox1.Text = FolderBrowserDialog1.SelectedPath
        End If
    End Sub

    Private Sub Label2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label2.Click

    End Sub
End Class

