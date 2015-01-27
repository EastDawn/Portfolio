/* Client Oriented */

# include "Head.h"

extern Bus Ongoing[10],Standingby[1],Waiting[5],Parking[34];

void Welcome()
{
	cout<<"\n\n";
	cout<<"  \n\t\t       ********************************";
	cout<<"  \n\t\t       *                              *";
	cout<<"  \n\t\t       *                              *";
	cout<<"  \n\t\t       *    Bus Management System     *";
	cout<<"  \n\t\t       *                              *";
	cout<<"  \n\t\t       *                              *";
	cout<<"  \n\t\t       ********************************";
	Sleep(2000);
}

void StartMenu()
{	
	char a;

	cout<<"\n\n\t\t\t   _________________________ ";
	cout<<"  \n\t\t\t  |                         |";
	cout<<"  \n\t\t\t  |       Start Guide       |";
	cout<<"  \n\t\t\t  |      ------*------      |";
	cout<<"  \n\t\t\t  |                         |";
	cout<<"  \n\t\t\t  | Follow the steps:       |";
	cout<<"  \n\t\t\t  |                         |";
	cout<<"  \n\t\t\t  |   1.Create the Queues   |";
	cout<<"  \n\t\t\t  |   2.Set the Bus         |";
	cout<<"  \n\t\t\t  |   3.Start the System    |";
	cout<<"  \n\t\t\t  |                         |";
	cout<<"  \n\t\t\t  |_________________________|";
	Sleep(3000);
	cout<<"\n\n\t\t\t>> Enter any key to countinue...";
	cout<<"\a\n\t\t\t >";
	cin>>a;
}

void StartDialog()
{
	cout<<"\n\n\t\t\t>> Are you sure to Start?";
	cout<<"  \n\t\t\t      1.Yes";
	cout<<"  \n\t\t\t      0.Quit";
	cout<<"\a\n\t\t\t >";
}

void MainMenu()
{
	cout<<"\n\n\t\t\t   _________________________ ";
	cout<<"  \n\t\t\t  |                         |";
	cout<<"  \n\t\t\t  |        Main Menu        |";
	cout<<"  \n\t\t\t  |       =====*=====       |";
	cout<<"  \n\t\t\t  |                         |";
	cout<<"  \n\t\t\t  |                         |";
	cout<<"  \n\t\t\t  |      1.Searching        |";
	cout<<"  \n\t\t\t  |      2.Counting         |";
	cout<<"  \n\t\t\t  |      3.Management       |";
	cout<<"  \n\t\t\t  |     *4.Setting          |";
	cout<<"  \n\t\t\t  |                         |";
	cout<<"  \n\t\t\t  |      0.Quit             |";
	cout<<"  \n\t\t\t  |                         |";
	cout<<"  \n\t\t\t  |_________________________|";
	cout<<"\n\n\t\t\t>> Select the order :";
	cout<<"\a\n\t\t\t >";
}

void SearchBox()
{
	cout<<"\n\n\t\t\t   _________________________ ";
	cout<<"  \n\t\t\t  |                         |";
	cout<<"  \n\t\t\t  |        Searching        |";
	cout<<"  \n\t\t\t  |       ^^^^^^^^^^^       |";
	cout<<"  \n\t\t\t  |   1.The Queue Info.     |";
	cout<<"  \n\t\t\t  |   2.The Bus Info.       |";
	cout<<"  \n\t\t\t  |                         |";
	cout<<"  \n\t\t\t  |                0.Back   |";
	cout<<"  \n\t\t\t  |_________________________|";
	cout<<"\n\n\t\t\t>> Select the order :";
	cout<<"\a\n\t\t\t >";
}

void QueueBox()
{
	cout<<"\n\n\t\t\t   _________________________ ";
	cout<<"  \n\t\t\t  | searching               |";
	cout<<"  \n\t\t\t  |                         |";
	cout<<"  \n\t\t\t  |       Queue Info.       |";
	cout<<"  \n\t\t\t  |                         |";
	cout<<"  \n\t\t\t  |      1.Ongoing          |";
	cout<<"  \n\t\t\t  |      2.Standingby       |";
	cout<<"  \n\t\t\t  |      3.Waiting          |";
	cout<<"  \n\t\t\t  |      4.Parking          |";
	cout<<"  \n\t\t\t  |      5.All              |";
	cout<<"  \n\t\t\t  |                         |";
	cout<<"  \n\t\t\t  |                0.Back   |";
	cout<<"  \n\t\t\t  |_________________________|";
	cout<<"\n\n\t\t\t>> Select the order :";
	cout<<"\a\n\t\t\t >";
}

void ShowQueueCase(char x)
{
	int i;
	char a;
	cout<<"\n\n\t\t\t------------------------------------";
		
	switch(x)
	{
		case '1':
		{
			cout<<"\n\n\t\t\t  There are 10 Bus in Ongoing Queue:";
			cout<<"\n\n\t\t\tStatus";
			cout<<"\t\tLocation ID";
			cout<<"\tSeat Limit\n";
			for(i=0;i<10;i++)
			{
				Ongoing[i].ShowBus();
			}
			cout<<"\n";
			cout<<"  \n\t\t\t-------------------------------------";
			break;
		}
		case '2':
		{
			cout<<"\n\n\t\t\t  There are 1 Bus in Standingby Queue:";
			cout<<"\n\n\t\t\tStatus";
			cout<<"\t\tLocation ID";
			cout<<"\tSeat Limit";
			Standingby[0].ShowBus();
			cout<<"\n";
			cout<<"  \n\t\t\t-------------------------------------";
			break;
		}
		case '3':
		{
			cout<<"\n\n\t\t\t  There are 5 Bus in Waiting Queue:";
			cout<<"\n\n\t\t\tStatus";
			cout<<"\t\tLocation ID";
			cout<<"\tSeat Limit";
			for(i=0;i<5;i++)
			{
				Waiting[i].ShowBus();
			}
			cout<<"\n";
			cout<<"  \n\t\t\t-------------------------------------";
			break;
		}
		case '4':
		{
			cout<<"\n\n\t\t\t  There are 34 Bus in Parking Queue:";
			cout<<"\n\n\t\t\tStatus";
			cout<<"\t\tLocation ID";
			cout<<"\tSeat Limit";
			for(i=0;i<34;i++)
			{
				Parking[i].ShowBus();
			}
			cout<<"\n";
			cout<<"  \n\t\t\t-------------------------------------";
			break;
		}
		case '5':
		{
			cout<<"\n\n\t\t\t  There are 50 Bus in the System Queue";
			cout<<"  \n\t\t\t    Including :";
			cout<<"  \n\t\t\t          10 Bus  in  Ongoing Queue";
			cout<<"  \n\t\t\t           1 Bus  in  Standingby Queue";
			cout<<"  \n\t\t\t           5 Bus  in  Waiting Queue";
			cout<<"  \n\t\t\t          34 Bus  in  Ongoing Queue";
			cout<<"\n\n\t\t\tStatus";
			cout<<"\t\tLocation ID";
			cout<<"\tSeat Limit";
			for(i=0;i<10;i++)
			{
				Ongoing[i].ShowBus();
			}
			cout<<"\n";
			Standingby[0].ShowBus();
			cout<<"\n";
			for(i=0;i<5;i++)
			{
				Waiting[i].ShowBus();
			}
			cout<<"\n";
			for(i=0;i<34;i++)
			{
				Parking[i].ShowBus();
			}
			cout<<"\n";
			cout<<"  \n\t\t\t-------------------------------------";
			break;
		}

		default: ErrorDialog();
	}
	Sleep(5000);
	cout<<"\n\n\t\t\t>> Enter any key to countinue...";
	cout<<"\a\n\t\t\t >";
	cin>>a;
}

void BusBox()
{
	cout<<"\n\n\t\t\t   _________________________ ";
	cout<<"  \n\t\t\t  | searching               |";
	cout<<"  \n\t\t\t  |                         |";
	cout<<"  \n\t\t\t  |        Box Info.        |";
	cout<<"  \n\t\t\t  |                         |";
	cout<<"  \n\t\t\t  |       1.By ID           |";
	cout<<"  \n\t\t\t  |      *2.By Location     |";
	cout<<"  \n\t\t\t  |                         |";
	cout<<"  \n\t\t\t  |                0.Back   |";
	cout<<"  \n\t\t\t  |_________________________|";
	cout<<"\n\n\t\t\t>> Select the order :";
	cout<<"\a\n\t\t\t >";
}

void ShowBusCase()
{				
	int i;
	char x[5];
	char a;

	cout<<"\n\n\t\t  _________________________________";
	cout<<"\n\n\t\t   Input Bus ID : ";
	for(i=0;i<5;i++)
	{
		cin>>x[i];
	}

	if(Bus::Check(x,Ongoing,50))
		cout<<"\n";
	else if(Bus::Check(x,Standingby,1))
		cout<<"\n";
	else if(Bus::Check(x,Waiting,5))
		cout<<"\n";
	else if(Bus::Check(x,Parking,50))
		cout<<"\n";
	else 
		cout<<"\n\n\t\t  No Record! "<<endl;

	cout<<"\n\n\t\t  _________________________________";
	Sleep(2000);
	cout<<"\n\n\t\t\t>> Enter any key to countinue...";
	cout<<"\a\n\t\t\t >";
	cin>>a;
}

void CountBox()
{
	cout<<"\n\n\t\t\t   _________________________ ";
	cout<<"  \n\t\t\t  |                         |";
	cout<<"  \n\t\t\t  |        Counting         |";
	cout<<"  \n\t\t\t  |       ^^^^^^^^^^        |";
	cout<<"  \n\t\t\t  |  1.Carrying Passenger   |";
	cout<<"  \n\t\t\t  |  2.Queue Info.          |";
	cout<<"  \n\t\t\t  |                         |";
	cout<<"  \n\t\t\t  |                0.Back   |";
	cout<<"  \n\t\t\t  |_________________________|";
	cout<<"\n\n\t\t\t>> Select the order :";
	cout<<"\a\n\t\t\t >";
}

void CountPassengerCase()
{
	int i;
	int Total=0;
	char a;

	for(i=0;i<10;i++)
	{
		Total=Total+Ongoing[i].Seats;
	}
	
	cout<<"\n\n\t\t  _________________________________________________";
	cout<<"\n\n\t\t   The number of passengers on loading is : "<<Total;
	cout<<"  \n\t\t  _________________________________________________";

	Sleep(2000);
	cout<<"\n\n\t\t\t>> Enter any key to countinue...";
	cout<<"\a\n\t\t\t >";
	cin>>a;
}

void CountQueueCase()
{
	int total1=0;
	int total2=0;
	int total3=0;
	int total4=0;
	int total=0;
	int i;
	char a;

	for(i=0;i<10;i++)
	{
		total1=total1+Ongoing[i].Seats;
	}

	total2=Standingby[0].Seats;

	for(i=0;i<5;i++)
	{
		total3=total3+Waiting[i].Seats;
	}

	for(i=0;i<34;i++)
	{
		total4=total4+Parking[i].Seats;
	}
	
	total=total1+total2+total3+total4;

	cout<<"\n\n\t\t ________________________________";
	cout<<"\n\n\t\t There are 4 Queues :";
	cout<<"\n\n\t\t  Queue      Bus      Total Seats";
	cout<<"\n\n\t\t Ongoing      10            "<<total1;
	cout<<"  \n\t\t Standby       1            "<<total2;
	cout<<"  \n\t\t Waiting       5            "<<total3;
	cout<<"  \n\t\t Parking      34            "<<total4;
	cout<<"\n\n\t\t Total        50            "<<total;
	cout<<"  \n\t\t ________________________________";

	Sleep(3000);
	cout<<"\n\n\t\t\t>> Enter any key to countinue...";
	cout<<"\a\n\t\t\t >";
	cin>>a;
}

void ManageBox()
{
	cout<<"\n\n\t\t\t   _________________________ ";
	cout<<"  \n\t\t\t  |                         |";
	cout<<"  \n\t\t\t  |        Management       |";
	cout<<"  \n\t\t\t  |       ^^^^^^^^^^^^      |";
	cout<<"  \n\t\t\t  |  1.Reset Running Time   |";
	cout<<"  \n\t\t\t  |                         |";
	cout<<"  \n\t\t\t  |                0.Back   |";
	cout<<"  \n\t\t\t  |_________________________|";
	cout<<"\n\n\t\t\t>> Select the order :";
	cout<<"\a\n\t\t\t >";
}

void ChangeRuningTimeCase(){};
/*{
	int i;
	char a;
	char space[8];

	cout<<"\n\n\t\t  ________________________________________________________";
	cout<<"\n\n\t\t   The running time of ongoing bus now is ( hh:mm:ss ): "<<ShowTime(Ongoing[0].RunningTime);
	cout<<"\n\n\t\t   Input the new running time ( hh:mm:ss ):";
	cin>>space;
	cout<<"\n\n\t\t   The running time has now been changed to ( hh:mm:ss ):";
	for(i=0;i<8;i++)
		cout<<space[i];
	cout<<"  \n\t\t  ________________________________________________________";

	

	Sleep(2000);
	cout<<"\n\n\t\t\t>> Enter any key to countinue...";
	cout<<"\a\n\t\t\t >";
	cin>>a;
}*/

void SetBox()
{
	cout<<"\n\n\t\t\t   _________________________ ";
	cout<<"  \n\t\t\t  |                         |";
	cout<<"  \n\t\t\t  |        *Setting         |";
	cout<<"  \n\t\t\t  |        ^^^^^^^^^        |";
	cout<<"  \n\t\t\t  |  *1.Reset the Queue     |";
	cout<<"  \n\t\t\t  |  *2.Reset the Bus       |";
	cout<<"  \n\t\t\t  |                         |";
	cout<<"  \n\t\t\t  |                0.Back   |";
	cout<<"  \n\t\t\t  |_________________________|";
	cout<<"\n\n\t\t\t>> Select the order :";
	cout<<"\a\n\t\t\t >";
}

void ResetQueueCase(){}

void ResetBusCase(){}

void QuitDialog()
{
	cout<<"\n\n\t\t\t>> Are you sure to Quit?";
	cout<<"  \n\t\t\t      1.Yes";
	cout<<"  \n\t\t\t      0.Cancel";
	cout<<"\a\n\t\t\t >";
}

void ErrorDialog()
{
	cout<<"\n\n\t\t\t Inputing Error!";
	Sleep(2000);
}

void End()
{
	cout<<"\n\n\n";
	cout<<"  \n\t\t  ********************************";
	cout<<"  \n\t\t  *                              *";
	cout<<"  \n\t\t  *  Copyrighted by :            *";
	cout<<"  \n\t\t  *                              *";
	cout<<"  \n\t\t  *            ³ÂÀö¾ê            *";
	cout<<"  \n\t\t  *            »ÆÐì½Ü            *";
	cout<<"  \n\t\t  *            Àî¾ýÐÐ            *";
	cout<<"  \n\t\t  *                              *";
	cout<<"  \n\t\t  *            Class.1           *";
	cout<<"  \n\t\t  *       Computer Science       *";
	cout<<"  \n\t\t  *             2011             *";
	cout<<"  \n\t\t  *                              *";
	cout<<"  \n\t\t  *      All right reserved      *";
	cout<<"  \n\t\t  *                              *";
	cout<<"  \n\t\t  *                              *";
	cout<<"  \n\t\t  *       _______________        *";
	cout<<"  \n\t\t  *      |               |       *";
	cout<<"  \n\t\t  *      |   Thank You   |       *";
	cout<<"  \n\t\t  *      |_______________|       *";
	cout<<"  \n\t\t  *                              *";
	cout<<"  \n\t\t  ********************************";
}
