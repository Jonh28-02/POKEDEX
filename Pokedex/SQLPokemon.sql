create database Proyect_Pokemon

use Proyect_Pokemon

create table Pokemones(
Id int primary key identity (1,1) not null,
Nombre varchar(40) not null,
Especie varchar(40) not null,
Tipo varchar(40) not null,
Habilidad text not null, 
Peso text not null,
Altura text not null,
Grupo varchar(40) not null,
Generacion varchar(40) not null,
);

INSERT INTO Pokemones 
values
('Decidueye', 'Pluma Flecha', 'Planta y Fantasma', 'Espesura', '  36.6 kg', '1.6 m', 'Volador', 'VII'),
('Pikachu', 'Ratón', 'Eléctrico', 'Electricidad estática', '    6.0 kg', '0.4 m', 'Campo y Hada', 'I'),
('Snorlax', 'Dormilón', 'Normal', 'Sebo e inmunidad', '460.0 kg', '2.1 m', 'Monstruo', 'I'),
('Charizard', 'Llama', 'Fuego y Volador', 'Poder solar', '  90.5 kg', '1.7 m', 'Monstruo-Dragón', 'I'),
('Lucario', 'Aura', 'Lucha y Acero', 'Impasible y foco interno', '  54.0 kg', '1.2 m', 'Campo y Humanoide', 'IV'),
('Gastly', 'Gas', 'Fantasma y Veneno', 'Levitación', '    0.1 kg', '1.3 m', 'Amorfo', 'I'),
('Ditto', 'Transformación', 'Normal', 'Flexibilidad', '    4.0 kg', '0.3 m', 'Ditto', 'I'),
('Piplup', 'Pingüino', 'Agua', 'Torrente', '    5.2 kg', '0.4 m', 'Campo y Agua', 'IV'),
('Onix', 'Serpiente roca', 'Roca y Tierra', 'Cabeza roca y robustez', '210.0 kg', '8.8 m', 'Mineral', 'I'),
('Magikarp', 'Pez', 'Agua', 'Nado rápido', '  10.0 kg', '0.9 m', 'Agua y Dragón', 'I')

select *from Pokemones


create proc MostrarPokemones
as
select *from Pokemones
go

CREATE proc InsertarPokemones
@nombre nvarchar (100),
@especie nvarchar (100),
@tipo nvarchar (100),
@habilidad text,
@peso text,
@altura text,
@grupo nvarchar (100),
@generacion nvarchar (100)
as
insert into Pokemones values (@nombre, @especie, @tipo, @habilidad, @peso, @altura, @grupo, @generacion)
go

CREATE proc EditarPokemones
@nombre nvarchar (100),
@especie nvarchar (100),
@tipo nvarchar (100),
@habilidad text,
@peso text,
@altura text,
@grupo nvarchar (100),
@generacion nvarchar (100),
@id int
as
update Pokemones set Nombre=@nombre, Especie=@especie, Tipo=@tipo, Habilidad=@habilidad, Peso=@peso, Altura=@altura, Grupo=@grupo, Generacion=@generacion
where Id=@id
go

CREATE proc EliminarPokemon
@idPokemon int
as
delete from Pokemones where Id=@idPokemon
go

exec MostrarPokemones
exec InsertarPokemones 'holas', 'aa', 'ee', 'ii', 'oo', 'uu', 'ae', 'ei'
exec EditarPokemones 'holiii', 'aass', 'esse', 'iiss', 'ooss', 'ussu', 'asse', 'ssei', 16
exec EliminarPokemon 11

truncate table Pokemones