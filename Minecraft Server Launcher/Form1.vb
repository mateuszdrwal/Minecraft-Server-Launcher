﻿'imports
Imports System.IO

Public Class Form1
    'variables
    Dim path As String
    Dim jarPath As String
    Dim jarName() As String
    'all of the help buttons and menu strip buttons. the reasons i said that i dont know and they should google it in some of the ones below instead of just not including the help button is because some forget that google exists. you can help me expand this if you want.
    Private Sub Button11_Click(sender As Object, e As EventArgs) Handles Button11.Click
        MessageBox.Show("Here, you can enter the preset if you are using superflat or customized world generation.", "Help")
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        MessageBox.Show("A kind of cheat protection. recommended to be turned off. When off, any player using a mod to fly will be kicked if in air for 5 seconds.", "Help")
    End Sub

    Private Sub Button10_Click(sender As Object, e As EventArgs) Handles Button10.Click
        MessageBox.Show("Honestly, i don't even know what this is. I found it in the server config so included it here. Google it if you want any help about it.", "Help")
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        MessageBox.Show("A kind of cheat protection. If off, non-premium players(the ones without the actual game purchased) will be able to join. This can be bad, as non-premium clients let you join with any username.", "Help")
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        MessageBox.Show("If on, the server will send anonymous debug information to mojang to help with bugs.", "Help")
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        MessageBox.Show("For advanced users. I dont know what this means, google it if you need any help with it.", "Help")
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        MessageBox.Show("How much stuff are OP's allowed to do?" & vbCr & "1: Ops can bypass spawn protection." & vbCr & "2: Ops can /clear, /difficulty, /effect, /gamemode, /gamerule, /give, and /tp, and can edit command blocks." & vbCr & "3: Ops can use /ban, /deop, /kick, and /op." & vbCr & "4: Ops can use /stop.", "Help")
    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        MessageBox.Show("after how many minutes should players be kicked if AFK?", "Help")
    End Sub

    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click
        MessageBox.Show("the number of milliseconds a single tick can take, before the server consideres itself as crashed, and forcefully shuts down.", "Help")
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        MessageBox.Show("I have no idea what this does, use google if you really need to use this feature.", "Help")
    End Sub

    Private Sub Button12_Click(sender As Object, e As EventArgs) Handles Button12.Click
        MessageBox.Show("paste a DIRECT link to the resource pack you want to use. a direct link means that if you go on the website, the item is immediately downloaded without clicking any buttons. sites like mediafire and dropbox will probably not work.", "Help")
    End Sub

    Private Sub SaveSettingsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SaveSettingsToolStripMenuItem.Click
        save()
        MessageBox.Show("settings saved!", "settings")
    End Sub

    Private Sub AboutToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AboutToolStripMenuItem.Click
        MessageBox.Show("created by mateuszdrwal, credit to Decleruz for the icon and some of the spelling correction", "About")
    End Sub

    Private Sub ExitToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExitToolStripMenuItem.Click
        Application.Exit()
    End Sub

    Private Sub PortforwardcomToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PortforwardcomToolStripMenuItem.Click
        If MessageBox.Show("there is a really good website that can help you forward ports. it is not made by me, i just found it and i am giving you the link. do you want to open the website now?", "Port Forwarding", MessageBoxButtons.YesNo) = DialogResult.Yes Then
            Process.Start("http://portforward.com/english/applications/port_forwarding/Minecraft_Server/")
        End If
    End Sub

    Private Sub GrapplToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles GrapplToolStripMenuItem.Click
        If MessageBox.Show("if you do not have access to your router or do not have permission to forward a port, a good solution is grappl. it lets you play with friends without forwarding a port." & vbCr & "to use it open it, choose to be anonymous and enter " & port.Value & " as the port. then the ip your friends use to join is displayed." & vbCr & "do you want to open grappl's website now?", "grappl", MessageBoxButtons.YesNo) = DialogResult.Yes Then
            Process.Start("http://grappl.io/")
        End If
    End Sub

    Private Sub OtherHelpToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles OtherHelpToolStripMenuItem.Click
        MessageBox.Show("write me an email at mateuszdrwalsredstonemc@gmail.com and i will answer your question as fast as i can.", "Contact")
    End Sub

    Private Sub Form1_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        save() 'auto save
    End Sub

    Private Sub HToolStripMenuItem_Click(sender As Object, e As EventArgs)
        MessageBox.Show("First, go to minecraft.net/download and download the server JAR. put it in an empty folder and change the path(in standard settings) to the folder you put the JAR in." & vbCr & "then, press the port forwarding tab and you will get help with forwarding ports. when you have done that, youre done!")
    End Sub

    Private Sub Button14_Click(sender As Object, e As EventArgs) Handles Button14.Click
        MessageBox.Show("for the server to work, you do not have to put anything here. only put something here if you know what you are doing.")
    End Sub

    Function getServerPath(x)
        Dim path_temp() As String = Split(x, "\")
        Dim path_temp2 As String = ""
        For i = 0 To path_temp.Length - 3
            path_temp2 = path_temp2 & path_temp(i) & "\"
        Next
        Return path_temp2
    End Function

    Function GetUserName() As String 'gets the username of the current user
        If TypeOf My.User.CurrentPrincipal Is
      Security.Principal.WindowsPrincipal Then
            Dim parts() As String = Split(My.User.Name, "\")
            Dim username As String = parts(1)
            Return username
        Else
            Return My.User.Name
        End If
    End Function

    Private Sub save() 'save loading (yes, i know i could have done the whole save system better, but this was the first that came into my mind when i made it and it works well so i have not bothered doing something better)
        If Not path = "\" Then
            Dim saver As New StreamWriter("C:\Users\" & GetUserName() & "\AppData\Roaming\MinecraftServerLauncherSaveFile_1_1_0.txt")
            'standard settings
            saver.WriteLine(Jar.Text)
            saver.WriteLine(world.Text)
            saver.WriteLine(ram.Text)
            'advanced checkboxes
            saver.WriteLine(gui.Checked.ToString)
            saver.WriteLine(flight.Checked.ToString)
            saver.WriteLine(npc.Checked.ToString)
            saver.WriteLine(Nether.Checked.ToString)
            saver.WriteLine(achivements.Checked.ToString)
            saver.WriteLine(animals.Checked.ToString)
            saver.WriteLine(hardcore.Checked.ToString)
            saver.WriteLine(online.Checked.ToString)
            saver.WriteLine(monsters.Checked.ToString)
            saver.WriteLine(command_blocks.Checked.ToString)
            saver.WriteLine(force_gamemode.Checked.ToString)
            saver.WriteLine(snooper.Checked.ToString)
            saver.WriteLine(pvp.Checked.ToString)
            saver.WriteLine(whitelist.Checked.ToString)
            'advanced numberboxes
            saver.WriteLine(difficulty.Text)
            saver.WriteLine(build_height.Text)
            saver.WriteLine(world_size.Text)
            saver.WriteLine(gamemode.Text)
            saver.WriteLine(compression.Text)
            saver.WriteLine(players.Text)
            saver.WriteLine(op.Text)
            saver.WriteLine(afk.Text)
            saver.WriteLine(tick.Text)
            saver.WriteLine(view.Text)
            saver.WriteLine(port.Text)
            saver.WriteLine(spawn.Text)
            'advanced textboxes
            saver.WriteLine(ip.Text)
            saver.WriteLine(pack_hash.Text)
            saver.WriteLine(motd.Text)
            saver.WriteLine(pack.Text)
            'generator
            saver.WriteLine(structures.Checked.ToString)
            saver.WriteLine(preset.Text)
            saver.WriteLine(level_type.Text)
            saver.WriteLine(seed.Text)
            'rcon and query
            saver.WriteLine(query.Checked.ToString)
            saver.WriteLine(rcon.Checked.ToString)
            saver.WriteLine(query_port.Text)
            saver.WriteLine(rcon_port.Text)
            saver.WriteLine(rcon_pass.Text)
            'server files
            saver.WriteLine(path)
            saver.WriteLine(jarPath)
            'close
            saver.Close()
        End If
    End Sub

    Sub loadSave() 'the loading function
        If File.Exists("C:\Users\" & GetUserName() & "\AppData\Roaming\MinecraftServerLauncherSaveFile_1_1_0.txt") Then
            Dim loader As New StreamReader("C:\Users\" & GetUserName() & "\AppData\Roaming\MinecraftServerLauncherSaveFile_1_1_0.txt")
            'standard settings
            Jar.Text = loader.ReadLine()
            world.Text = loader.ReadLine()
            ram.Value = loader.ReadLine()
            'advanced checkboxes
            gui.Checked = loader.ReadLine()
            flight.Checked = loader.ReadLine()
            npc.Checked = loader.ReadLine()
            Nether.Checked = loader.ReadLine()
            achivements.Checked = loader.ReadLine()
            animals.Checked = loader.ReadLine()
            hardcore.Checked = loader.ReadLine()
            online.Checked = loader.ReadLine()
            monsters.Checked = loader.ReadLine()
            command_blocks.Checked = loader.ReadLine()
            force_gamemode.Checked = loader.ReadLine()
            snooper.Checked = loader.ReadLine()
            pvp.Checked = loader.ReadLine()
            whitelist.Checked = loader.ReadLine()
            'advanced numberboxes
            difficulty.Value = loader.ReadLine()
            build_height.Value = loader.ReadLine()
            world_size.Value = loader.ReadLine()
            gamemode.Value = loader.ReadLine()
            compression.Value = loader.ReadLine()
            players.Value = loader.ReadLine()
            op.Value = loader.ReadLine()
            afk.Value = loader.ReadLine()
            tick.Value = loader.ReadLine()
            view.Value = loader.ReadLine()
            port.Value = loader.ReadLine()
            spawn.Value = loader.ReadLine()
            'advanced textboxes
            ip.Text = loader.ReadLine()
            pack_hash.Text = loader.ReadLine()
            motd.Text = loader.ReadLine()
            pack.Text = loader.ReadLine()
            'generator
            structures.Checked = loader.ReadLine()
            preset.Text = loader.ReadLine()
            level_type.Text = loader.ReadLine()
            seed.Text = loader.ReadLine()
            'rcon and query
            query.Checked = loader.ReadLine()
            rcon.Checked = loader.ReadLine()
            query_port.Value = loader.ReadLine()
            rcon_port.Value = loader.ReadLine()
            rcon_pass.Text = loader.ReadLine()
            'server files
            path = loader.ReadLine()
            jarPath = loader.ReadLine
            'Close
            loader.Close()
        End If
    End Sub

    Sub createPorp() 'the function that generates the server.properties file that minecraft servers read
        Dim propWriter As New StreamWriter(path & "server.properties")
        'standard settings
        propWriter.WriteLine("level-name=" & world.Text)
        'advanced checkboxes
        propWriter.WriteLine("allow-flight=" & flight.Checked.ToString)
        propWriter.WriteLine("spawn-npcs=" & npc.Checked.ToString)
        propWriter.WriteLine("allow-nether=" & Nether.Checked.ToString)
        propWriter.WriteLine("announce-player-achievements=" & achivements.Checked.ToString)
        propWriter.WriteLine("spawn-animals=" & animals.Checked.ToString)
        propWriter.WriteLine("hardcore=" & hardcore.Checked.ToString)
        propWriter.WriteLine("online-mode=" & online.Checked.ToString)
        propWriter.WriteLine("spawn-monsters=" & monsters.Checked.ToString)
        propWriter.WriteLine("enable-command-block=" & command_blocks.Checked.ToString)
        propWriter.WriteLine("force-gamemode=" & force_gamemode.Checked.ToString)
        propWriter.WriteLine("snooper-enabled=" & snooper.Checked.ToString)
        propWriter.WriteLine("pvp=" & pvp.Checked.ToString)
        propWriter.WriteLine("white-list=" & whitelist.Checked.ToString)
        'advanced numberboxes
        propWriter.WriteLine("difficulty=" & (difficulty.Text))
        propWriter.WriteLine("max-build-height=" & build_height.Text)
        propWriter.WriteLine("max-world-size=" & world_size.Text)
        propWriter.WriteLine("gamemode=" & gamemode.Text)
        propWriter.WriteLine("network-compression-threshold=" & compression.Text)
        propWriter.WriteLine("max-players=" & players.Text)
        propWriter.WriteLine("op-permission-level=" & op.Text)
        propWriter.WriteLine("player-idle-timeout=" & afk.Text)
        propWriter.WriteLine("max-tick-time=" & tick.Text)
        propWriter.WriteLine("view-distance=" & view.Text)
        propWriter.WriteLine("server-port=" & port.Text)
        propWriter.WriteLine("spawn-protection=" & spawn.Text)
        'advanced textboxes
        propWriter.WriteLine("server-ip=" & ip.Text)
        propWriter.WriteLine("resource-pack-hash=" & pack_hash.Text)
        propWriter.WriteLine("motd=" & motd.Text)
        propWriter.WriteLine("resource-pack=" & pack.Text)
        'generator
        propWriter.WriteLine("generate-structures=" & structures.Checked.ToString)
        propWriter.WriteLine("generator-settings=" & preset.Text)
        propWriter.WriteLine("level-type=" & level_type.Text)
        propWriter.WriteLine("level-seed=" & seed.Text)
        'rcon and query
        propWriter.WriteLine("enable-query=" & query.Checked.ToString)
        propWriter.WriteLine("enable-rcon=" & rcon.Checked.ToString)
        propWriter.WriteLine("query.port=" & query_port.Text)
        propWriter.WriteLine("rcon.port=" & rcon_port.Text)
        propWriter.WriteLine("rcon.password=" & rcon_pass.Text)
        'close
        propWriter.Close()
    End Sub

    Function serverPath() 'getting the server path
        OpenFileDialog1.ShowDialog()
        Dim tempPath As String = getServerPath(OpenFileDialog1.FileName & "\")
        Dim tempJarPath As String = OpenFileDialog1.FileName & "\"
        If path = "\" Then
            Return False
        Else
            path = tempPath
            jarPath = tempJarPath
            Jar.Text = jarPath
            Return True
        End If
    End Function

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        OpenFileDialog1.Filter = "Jar Files(*.jar)|*.jar"
        If Not File.Exists("C:\Users\" & GetUserName() & "\AppData\Roaming\MinecraftServerLauncherSaveFile_1_1_0.txt") Then 'checking if there is an save file, if not asking for the folder with all the server files
            If Not serverPath() Then
                MessageBox.Show("You did not select a jar file. the application will now close.")
                Application.Exit()
            End If
        Else
            loadSave()
        End If
        Jar.Text = jarPath
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click 'starting the server
        Try
            createPorp() 'creating properties file
            Dim bat As New StreamWriter(path & "simpleStart.bat") 'creating the run batch file
            bat.WriteLine("::this is an server start file automaticly generated every time you launch the server using the minecraft server launcher. you can also open this file directly if you want to run the server with the last used settings.")
            bat.WriteLine("cd " & path)
            bat.WriteLine("cls")
            jarName = Split(Jar.Text, "\")
            If gui.Checked Then
                bat.WriteLine("java -Xmx" & ram.Value & "m -Xms" & ram.Value / 4 & "m -jar " & jarName(jarName.Length - 2))
            Else
                bat.WriteLine("java -Xmx" & ram.Value & "m -Xms" & ram.Value / 4 & "m -jar " & jarName(jarName.Length - 2) & " nogui")
            End If
            bat.WriteLine("pause")
            bat.Close()
            Shell(path & "simpleStart.bat") 'running the batch file to start the server
        Catch ex As Exception
            MessageBox.Show("an error has occurred. details:" & vbCr & ex.ToString)
        End Try
    End Sub

    Private Sub Button13_Click(sender As Object, e As EventArgs) Handles Button13.Click 'changing path
        serverPath()
    End Sub

    Private Sub HelpToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles HelpToolStripMenuItem.Click
        help_form.Show()
    End Sub
End Class