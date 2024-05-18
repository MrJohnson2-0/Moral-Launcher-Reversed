//Enjoy Launch code
public async void Launch()
	{
		try
		{
			if (running)
			{
				return;
			}
			running = true;
			if (Vars.Path1 == "NONE")
			{
				Vars.Path1 = UpdateINI.ReadValue("Auth", "Path1");
			}
			string path = Vars.Path1;
			if (path != "NONE")
			{
				if (File.Exists(Path.Combine(path, "FortniteGame\\Binaries\\Win64\\FortniteClient-Win64-Shipping.exe")))
				{
					if (Vars.Email == "NONE")
					{
						Vars.Email = UpdateINI.ReadValue("Auth", "Email");
					}
					if (Vars.Password == "NONE")
					{
						Vars.Password = UpdateINI.ReadValue("Auth", "Password");
					}
					if (Vars.Email == "NONE" || Vars.Password == "NONE")
					{
						System.Windows.MessageBox.Show("Your login was incorrect, please logout!");
					}
					Process[] processesByName = Process.GetProcessesByName("FortniteClient-Win64-Shipping");
					foreach (Process process in processesByName)
					{
						try
						{
							if (process.MainModule.FileName.StartsWith(path))
							{
								process.Kill();
								process.WaitForExit();
							}
						}
						catch
						{
						}
					}
					new WebClient().DownloadFile("https://drive.google.com/uc?export=download&id=1n20ojNuzhKWDi38-_l0jbym_MZyhBYpr", Path.Combine(path, "Engine\\Binaries\\ThirdParty\\NVIDIA\\NVaftermath\\Win64", "GFSDK_Aftermath_Lib.x64.dll"));
					Game.Start(path, "-epicapp=Fortnite -epicenv=Prod -epiclocale=en-us -epicportal -nobe -fromfl=eac -fltoken=919348d6add4c4c7c7507e61 -skippatchcheck", Vars.Email, Vars.Password);
					FakeAC.Start(path, "FortniteClient-Win64-Shipping_BE.exe", "-epicapp=Fortnite -epicenv=Prod -epiclocale=en-us -epicportal -noeac -fromfl=be -fltoken=h1cdhchd10150221h130eB56 -skippatchcheck");
					FakeAC.Start(path, "FortniteLauncher.exe", "-epicapp=Fortnite -epicenv=Prod -epiclocale=en-us -epicportal -noeac -fromfl=be -fltoken=h1cdhchd10150221h130eB56 -skippatchcheck", "dsf");
					try
					{
						FakeAC._FNLauncherProcess.Close();
						FakeAC._FNAntiCheatProcess.Close();
					}
					catch (Exception)
					{
					}
					ShowWindow(Process.GetCurrentProcess().MainWindowHandle, 6);
					try
					{
						Game._FortniteProcess.WaitForExit();
					}
					catch (Exception)
					{
					}
					try
					{
						try
						{
							Kill();
						}
						catch
						{
						}
					}
					catch (Exception)
					{
						System.Windows.MessageBox.Show("An error occurred while closing Fake AC!");
					}
					running = false;
				}
				else
				{
					System.Windows.MessageBox.Show("Selected path is not a valid fortnite installation!");
				}
			}
			else
			{
				System.Windows.MessageBox.Show("Please add your game path in settings!");
			}
		}
		catch (Exception ex4)
		{
			System.Windows.MessageBox.Show(ex4.ToString());
		}
	}
