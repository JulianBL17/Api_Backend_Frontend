CREATE TABLE Tools (
	Id INTEGER PRIMARY KEY,
	Name text NOT NULL,
	Price INTEGER NOT NULL,
	Description TEXT NOT NULL
);

Insert into Tools (Name, Price, Description) values("Alicate", 10, "Es una herramienta manual cuyos usos van desde sujetar piezas al corte o moldeado de distintos materiales");
Insert into Tools (Name, Price, Description) values("Martillo", 20, "Es una herramienta utilizada para golpear directamente o indirectamente");
Insert into Tools (Name, Price, Description) values("Destornillador", 30, "Se utiliza para apretar y aflojar tornillos y otros elementos de máquinas que requieren poca fuerza de apriete y que generalmente son de diámetro pequeño");
