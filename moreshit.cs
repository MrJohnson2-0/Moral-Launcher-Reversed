private async void StartLoadingProcess()
	{
		await Task.Delay(1000);
		WebClient webClient = new WebClient();
		try
		{
			string value = webClient.DownloadString("https://drive.google.com/uc?export=download&id=1FxhBH3XnryqoEjLwJWG3rV9AGPSJw-tU");
			if (!"0.0.9".Equals(value))
			{
				MessageBox.Show("Your launcher is out of date. Please check the discord.");
				Application.Current.Shutdown();
				return;
			}
		}
		catch (Exception)
		{
			MessageBox.Show("Failed to check for updates, try checking if backend is on.");
			Application.Current.Shutdown();
			return;
		}
		await Task.Delay(1000);
		UpdateINI.ReadValue("Auth", "Email");
		UpdateINI.ReadValue("Auth", "Password");
		new Window3().Show();
		Close();
	}


public static void InitializeRPC()
	{
		client = new DiscordRpcClient("1231016249673383997");
		client.Initialize();
		Button[] buttons = new Button[2]
		{
			new Button
			{
				Label = "Join Morals Discord!",
				Url = "https://discord.gg/moralfn"
			},
			new Button
			{
				Label = "Join Support Server!",
				Url = "https://discord.gg/AySnhAKMET"
			}
		};
		presence = new RichPresence
		{
			Details = "In Launcher",
			State = "Project Moral",
			Timestamps = rpctimestamp,
			Buttons = buttons,
			Assets = new Assets
			{
				LargeImageKey = "https://drive.google.com/uc?export=download&id=1SoZqCBLKJ670x3cCJt5BRDpHcqLcTYcu",
				LargeImageText = "Project Moral",
				SmallImageKey = "",
				SmallImageText = ""
			}
		};
		SetState("Project Moral");
	}

public static void SetState(string state, bool watching = false)
	{
		if (watching)
		{
			state = state ?? "";
		}
		presence.State = state;
		client.SetPresence(presence);
	}
