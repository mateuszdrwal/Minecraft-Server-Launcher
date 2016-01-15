Public Class help_form
    Private Sub ListBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListBox1.SelectedIndexChanged
        Select Case ListBox1.SelectedIndex
            Case 0
                Label1.Text = "you have probably not forwarded the port or you did it incorrectly. check the port forwarding tab for more information."
            Case 1
                Label1.Text = "your friends use your ip:port to join the server. to find your ip, go to http://www.ipchicken.com and the ip is the big blue text. add an :" & Form1.port.Value.ToString & " to the end and thats the ip your friends are going to use to connect to your server."
            Case 2
                Label1.Text = "you join by typing localhost as the ip."
            Case 3
                Label1.Text = "You have specified the wrong path of the server jar. double check that your server is not an .exe/executeable and make sure the right path is selected."
        End Select
    End Sub

    Private Sub help_form_closed(sender As Object, e As EventArgs) Handles MyBase.Closed
        Label1.Text = ""
    End Sub
End Class