create table Sponsor
(
	Id int identity(1,1) primary key,
	Name nvarchar(100),
	ContactName nvarchar(100),
	ContactNumber nvarchar(20),
	Website nvarchar(200)
)

insert into Sponsor (Name, ContactName, ContactNumber, Website)
values('Blue Star', 'Kiki Durham', '972-445-5678', 'www.russelldurham.com')

create table Listing
(
 Id int identity(1,1) primary key,
 SponsorId int not null,
 Title nvarchar(100),
 [Description] nvarchar(max)
 
 constraint fk_Sponsor foreign key(SponsorId)
 references Sponsor(Id)
)

select * from Sponsor
insert into Listing(SponsorId, Title, [Description])
values(1, 'Great Job with Medical Software!', 'this will be a fantastic job, with the money of blah blah blah lorem ipsum for default lol at russell and kiki snuggling together')

select * from Listing

create table Applicant
(
	Id int identity(1,1) primary key,
	ListingId int not null,
	FirstName nvarchar(100),
	LastName nvarchar(100),
	Email nvarchar(100),
	Phone nvarchar(100)

	constraint fk_Listing foreign key(ListingId)
	references Listing(Id)
)

select * from Listing