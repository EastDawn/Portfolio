/* Main */

# include "Head.h"

int main()
{
	int T;
	int q;

	Welcome();

	StartMenu();
	SetFunc();
	StartDialog();
	cin>>SysStatus;
	if(SysStatus=='1')
		MainMenu();
	else
	{
		QuitDialog();
		cin>>SysStatus;
		if(SysStatus=='1')
		{
			End();
			Sleep(5000);
			return 0;
		}
		else
			MainMenu();
	}
	
	while(1)
	{
		cin>>MenuStatus;

		if(MenuStatus=='0')
		{
			QuitDialog();
			cin>>SysStatus;

			if(SysStatus=='1')
				break;
		}
		else if(MenuStatus=='1')
		{
			
			SearchBox();
			while(1)
			{
				cin>>BoxStatus;

				if(BoxStatus=='0')
					break;
				else if(BoxStatus=='1')
				{
					QueueBox();
					while(1)
					{
						cin>>CaseStatus;

						if(CaseStatus=='0')
							break;
						else if(CaseStatus=='1')
							ShowQueueCase('1');
						else if(CaseStatus=='2')
							ShowQueueCase('2');
						else if(CaseStatus=='3')
							ShowQueueCase('3');
						else if(CaseStatus=='4')
							ShowQueueCase('4');
						else if(CaseStatus=='5')
							ShowQueueCase('5');
						else
							ErrorDialog();

						QueueBox();
					}
				}
				else if(BoxStatus=='2')
				{
					BusBox();
					while(1)
					{
						cin>>CaseStatus;

						if(CaseStatus=='0')
							break;
						else if(CaseStatus=='1')
							ShowBusCase();
						else
							ErrorDialog();

						BusBox();
					}
				}
				else
					ErrorDialog();

				SearchBox();
			}
		}
		else if(MenuStatus=='2')
		{
			CountBox();
			while(1)
			{
				cin>>BoxStatus;

				if(BoxStatus=='0')
					break;
				else if(BoxStatus=='1')
					CountPassengerCase();
				else if(BoxStatus=='2')
					CountQueueCase();
				else
					ErrorDialog();

				CountBox();
			}
		}
		else if(MenuStatus=='3')
		{
			
			ManageBox();
			while(1)
			{
				cin>>BoxStatus;

				if(BoxStatus=='0')
					break;
				else if(BoxStatus=='1')
					ChangeRuningTimeCase();
				else
					ErrorDialog();

				ManageBox();
			}
		}
		else if(MenuStatus=='4')
		{
			SetBox();
			while(1)
			{
				cin>>BoxStatus;

				if(BoxStatus=='0')
					break;
				else if(BoxStatus=='1')
					ResetQueueCase();
				else if(BoxStatus=='2')
					ResetBusCase();
				else
					ErrorDialog();

				SetBox();
			}
		}
		else
			ErrorDialog();

		srand(time(NULL));
		T=rand()%5+1;
		for(q=0;q<T;q++)
			OneStep();

		MainMenu();
	}

	End();
	Sleep(5000);

	return 0; 
}