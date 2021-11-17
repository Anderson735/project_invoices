/*
CREATE SCHEMA Facturas;
USE Facturas;

CREATE TABLE invoice 
( 	
	id int(11) primary key auto_increment not null,
    cod char(20),
    cliente char(20)  not null
);



CREATE TABLE cliente 
( 	
	id char(20) primary key not null,
	nombre varchar(100) not null,
    apellido varchar(100) not null,
    factura int(11) 
);

select * from invoice_detail where id_invoice = 1;




CREATE TABLE invoice_detail 
( 	
	id int(11) primary key auto_increment  not null,
	id_invoice char(20) not null,
    descripcion varchar(100) not null,
    valor decimal
);


alter table cliente add foreign key(factura) references invoice(id);
alter table invoice_detail  add foreign key(id_invoice) references invoice(id);

*/
