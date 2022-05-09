CREATE TABLE Ingredient(
   Id_Ingredient INT IDENTITY,
   nom_ingredient VARCHAR(max),
   PRIMARY KEY(Id_Ingredient)
);

CREATE TABLE imageIngredient(
   Id_Photo INT IDENTITY,
   nom_photo VARCHAR(max),
   Id_Ingredient INT NOT NULL,
   PRIMARY KEY(Id_Photo),
   FOREIGN KEY(Id_Ingredient) REFERENCES Ingredient(Id_Ingredient)
);

CREATE TABLE Type_recette(
   Id_Type_recette INT IDENTITY,
   nom_type_recette VARCHAR(255),
   PRIMARY KEY(Id_Type_recette)
);

CREATE TABLE Ustensiles(
   Id_Ustensiles INT IDENTITY,
   nom_ustensile VARCHAR(50),
   PRIMARY KEY(Id_Ustensiles)
);

CREATE TABLE Users(
   Id_User INT IDENTITY,
   nom_user VARCHAR(255),
   email_user VARCHAR(max),
   password VARCHAR(max),
   pseudo VARCHAR(255),
   admin INT,
   PRIMARY KEY(Id_User)
);

CREATE TABLE Recette(
   Id_Recette INT IDENTITY,
   nom_recette VARCHAR(max),
   nbr_personne INT,
   description_recette VARCHAR(max),
   temps INT,
   favoris BIT,
   note INT,
   is_public BIT,
   Id_User INT NOT NULL,
   Id_Type_recette INT NOT NULL,
   PRIMARY KEY(Id_Recette),
   FOREIGN KEY(Id_User) REFERENCES Users(Id_User),
   FOREIGN KEY(Id_Type_recette) REFERENCES Type_recette(Id_Type_recette)
);

CREATE TABLE Etape_recette(
   Id_Etape_recette INT IDENTITY,
   nom_etape VARCHAR(255),
   description_etape VARCHAR(max),
   Id_Recette INT NOT NULL,
   PRIMARY KEY(Id_Etape_recette),
   FOREIGN KEY(Id_Recette) REFERENCES Recette(Id_Recette)
);

CREATE TABLE imageRecette(
   Id_Photo INT IDENTITY,
   nom_photo VARCHAR(max),
   Id_Recette INT NOT NULL,
   PRIMARY KEY(Id_Photo),
   FOREIGN KEY(Id_Recette) REFERENCES Recette(Id_Recette)
);

CREATE TABLE recette_ingrdients(
   Id_Recette INT,
   Id_Ingredient INT,
   quantite_ingredient DECIMAL(15,2),
   untite VARCHAR(50),
   PRIMARY KEY(Id_Recette, Id_Ingredient),
   FOREIGN KEY(Id_Recette) REFERENCES Recette(Id_Recette),
   FOREIGN KEY(Id_Ingredient) REFERENCES Ingredient(Id_Ingredient)
);

CREATE TABLE recette_ustencile(
   Id_Recette INT,
   Id_Ustensiles INT,
   quantite_ustencile INT,
   PRIMARY KEY(Id_Recette, Id_Ustensiles),
   FOREIGN KEY(Id_Recette) REFERENCES Recette(Id_Recette),
   FOREIGN KEY(Id_Ustensiles) REFERENCES Ustensiles(Id_Ustensiles)
);
