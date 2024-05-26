'Made by the funyman
'Date of creation was 25/may/2024 at around 11:58pm i think

Imports System.IO 'very important
Public Class vrToggler
    ' Declares public variables
    Dim rblxSettingsLocation As String
    Dim settingLine As Integer
    Dim vrActive As Boolean
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Sets the roblox settings location on startup and runs a vr state check / set
        rblxSettingsLocation = "C:\Users\" & SystemInformation.UserName & "\AppData\Local\Roblox\GlobalBasicSettings_13.xml"
        vrState()
    End Sub
    Private Sub btnToggle_Click(sender As Object, e As EventArgs) Handles btnToggle.Click
        Dim lines() As String = IO.File.ReadAllLines(rblxSettingsLocation) ' Creates essentially a digging turtle that digs through every line of a given file (in this case the settings folder)
        If vrActive = True Then
            'Checks to see if its enabled and if it is then it will get every line of code and alter the line with the VREnabled setting and then runs the vr check again.

            lines(settingLine) = "			<bool name=" & """" & "VREnabled" & """" & ">false</bool>"
            IO.File.WriteAllLines(rblxSettingsLocation, lines)
            vrState()
        ElseIf vrActive = False Then
            'Checks to see if its disabled and if it is then it will have the opposite effect expect for the vr check

            lines(settingLine) = "			<bool name=" & """" & "VREnabled" & """" & ">true</bool>"
            IO.File.WriteAllLines(rblxSettingsLocation, lines)
            vrState()
        End If
    End Sub

    'The code that runs only when its called and will get the line the VREnabled setting it is on, check if VREnabled is true and setis the VRStatus
    Sub vrState()
        Dim lines() As String = File.ReadAllLines(rblxSettingsLocation) ' This variable is used to read lines AMOUNT to target the VREnabled setting
        Dim reader As StreamReader = File.OpenText(rblxSettingsLocation) ' This variable is used to read what the line CONTAINS to check if VREnabled = True

        'This code counts the lines and goes through all of them 1 by 1, the -1 is used because the first line of a text file is line(0) and the lines.Length counts it as 1
        For n = 0 To lines.Length - 1
            Dim line As String = reader.ReadLine
            If line = "			<bool name=" & """" & "VREnabled" & """" & ">true</bool>" Then
                settingLine = n
                vrActive = True
                lblVRStatus.Text = "VR is currently: Enabled"
            ElseIf line = "			<bool name=" & """" & "VREnabled" & """" & ">false</bool>" Then
                settingLine = n
                vrActive = False
                lblVRStatus.Text = "VR is currently: Disabled"
            End If
        Next
        reader.Close() ' Closes the reader because 
    End Sub
End Class