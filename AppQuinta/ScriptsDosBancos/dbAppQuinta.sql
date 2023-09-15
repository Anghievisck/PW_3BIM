drop database dbAppBanco;
create database dbAppBanco;
use dbAppBanco;

create table tbUsuario(
	IdUser int primary key auto_increment,
	NomeUser varchar(50) not null,
    Cargo varchar(50) not null,
    DataNasc datetime
);

insert into tbUsuario(NomeUser, Cargo, DataNasc)
values ('Rafaella', 'Lider do TCC', '2005/08/18'),
	   ('Pedro', 'Aluno', '2006/01/20'),
       ('Terceiro', 'Ser apagado', '2000/01/01');
       
select * from tbUsuario;