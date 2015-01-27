/* Bus Class */

# include "Head.h"

Bus::Bus()
{
	SetBusLoc();
	SetBusID();
	SetSeats();
}

Bus::~Bus(){}

void Bus::SetBusLoc()
{
	int i;

	srand(TIME+2758);
	i=rand()%100+1;

	if(i>=0&&i<=50)
		BusLoc='Y';
	else
		BusLoc='C';
}

void Bus::SetBusID()
{
	int i;
	
	for(i=0;i<5;i++)
	{
		TIME=TIME+2758;
		srand(TIME);
		BusID[i]=rand()%9+49;
	}
}

void Bus::SetSeats()
{
	int i;

	TIME=TIME+2758;
	srand(TIME);
	i=rand()%100+1;

	if(i>=0&&i<=30)
		Seats=35;
	else if(i>=31&&i<=70)
		Seats=45;
	else
		Seats=55;
}

void Bus::SetRuningTime()
{
	RunningTime=3600;
}

void Bus::ShowBus()
{
	int i;

	cout<<"  \n\t\t\t"<<Status;
	cout<<"\t\t"<<BusLoc;
	cout<<"  ";
	for(i=0;i<5;i++)
	{
		cout<<BusID[i];
	}
	cout<<"\t"<<Seats;
}

int Bus::Check(char s[],Bus p[],int n)
{
	int i,j;
	int flag=0;
	int count;

	for(i=0;i<n;i++)
	{
		count=0;
		for(j=0;j<5;j++)
		{
			if(s[j]==p[i].BusID[j])
				count++;
			else
				break;
		}
		if(count==5)
		{
			p[i].ShowBus();
			flag=1;
			return 1;
		}
	}
	if(flag==0)
		return 0;

	return 0;
}

void Bus::OntoPar()
{
	Status="Parking";
}

Bus Ongoing[10],Standingby[1],Waiting[5],Parking[34];