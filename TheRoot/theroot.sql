 create database theroot;
 
 use theroot;

 create table usuarios(
  id int identity(1,1) primary key,
  nombre varchar(200) not null,
  usuario varchar(220) not null, 
  pass varchar(200)not null,
  tipo varchar(50)not null
 );

 insert into usuarios values('Rafaelito','rafa','1234','Admin');
 insert into usuarios values('Benjamin','benja','12345','Admin');
 insert into usuarios values('Sergio','sergio','12346','Usuario');
 insert into usuarios values('Lisandry','wachi','12347','Usuario');

 select * from usuarios;

 