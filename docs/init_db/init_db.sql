insert into public."Agent"("PlayerId", "Surname", "Country")
values(1, 'Petrov', 'Russia');
insert into public."Agent"("PlayerId", "Surname", "Country")
values(2, 'Ivanov', 'Spain');
insert into public."Agent"("PlayerId", "Surname", "Country")
values(3, 'Sidorov', 'Russia');

insert into public."Club"("Name", "Country", "FoundationDate")
values('Ajax', 'Netherlands', 1958);
insert into public."Club"("Name", "Country", "FoundationDate")
values('Bologna', 'Italy', 1997);
insert into public."Club"("Name", "Country", "FoundationDate")
values('Burnley', 'England', 1991);

insert into public."Coach"("Surname", "Country", "WorkExperience")
values('Bridges', 'Uzbekistan', 16);
insert into public."Coach"("Surname", "Country", "WorkExperience")
values('Fuentes', 'Australia', 24);
insert into public."Coach"("Surname", "Country", "WorkExperience")
values('Rivers', 'Japan', 35);

insert into public."Player"("ClubId", "Surname", "Rating", "Country", "Price")
values(1, 'Messi', 94, 'Argentina', 180000);
insert into public."Player"("ClubId", "Surname", "Rating", "Country", "Price")
values(2, 'Ronaldo', 94, 'Portugal', 168000);
insert into public."Player"("ClubId", "Surname", "Rating", "Country", "Price")
values(3, 'Hazard', 91, 'Belgium', 147000);

insert into public."Squad"("CoachId", "Name", "Rating")
values(1, 'Legend 17', 0);
insert into public."Squad"("CoachId", "Name", "Rating")
values(2, 'Pink Rabbit', 0);

insert into public."User"("Login", "Password", "Permission")
values('admin', 'admin', 'admin');
insert into public."User"("Login", "Password", "Permission")
values('kovkir', '111', 'user');