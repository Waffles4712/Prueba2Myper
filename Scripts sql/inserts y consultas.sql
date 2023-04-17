insert into Trabajadores (TipoDocumento, NumeroDocumento, Nombres, Sexo, IdDepartamento, IdProvincia,IdDistrito) values ('DNI','72914361','Neil Tafur', 'M', 1,3,1859)

select * from Trabajadores
delete from trabajadores

create table TipoDocumento(
IdTipo int identity(1,1),
Tipodocumento char(3) primary key
)
SELECT * FROM TipoDocumento
insert into TipoDocumento (Tipodocumento) values ('DNI'),('C.E')
insert into Sexo (Sexo) values ('F'),('M')

select * from Departamento
delete from Trabajadores where id=27
create proc


