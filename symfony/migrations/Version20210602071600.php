<?php

declare(strict_types=1);

namespace DoctrineMigrations;

use Doctrine\DBAL\Schema\Schema;
use Doctrine\Migrations\AbstractMigration;

/**
 * Auto-generated Migration: Please modify to your needs!
 */
final class Version20210602071600 extends AbstractMigration
{
    public function getDescription(): string
    {
        return '';
    }

    public function up(Schema $schema): void
    {
        // this up() migration is auto-generated, please modify it to your needs
        $this->addSql('CREATE TABLE cgu (id INT AUTO_INCREMENT NOT NULL, description LONGTEXT NOT NULL, PRIMARY KEY(id)) DEFAULT CHARACTER SET utf8mb4 COLLATE `utf8mb4_unicode_ci` ENGINE = InnoDB');
        $this->addSql('CREATE TABLE cgv (id INT AUTO_INCREMENT NOT NULL, description LONGTEXT NOT NULL, PRIMARY KEY(id)) DEFAULT CHARACTER SET utf8mb4 COLLATE `utf8mb4_unicode_ci` ENGINE = InnoDB');
        $this->addSql('CREATE TABLE contact (id INT AUTO_INCREMENT NOT NULL, email VARCHAR(255) NOT NULL, message LONGTEXT NOT NULL, name VARCHAR(255) NOT NULL, subject VARCHAR(255) NOT NULL, PRIMARY KEY(id)) DEFAULT CHARACTER SET utf8mb4 COLLATE `utf8mb4_unicode_ci` ENGINE = InnoDB');
        $this->addSql('ALTER TABLE blog CHANGE date_b date DATETIME NOT NULL, CHANGE titre_b titre VARCHAR(255) NOT NULL');
        $this->addSql('ALTER TABLE blog_coms DROP FOREIGN KEY FK_B2D3B210DAE07E97');
        $this->addSql('DROP INDEX IDX_B2D3B210DAE07E97 ON blog_coms');
        $this->addSql('ALTER TABLE blog_coms CHANGE blog_id relation_blog_id INT NOT NULL, CHANGE contenu_bc contenu LONGTEXT NOT NULL, CHANGE date_bc date DATETIME NOT NULL');
        $this->addSql('ALTER TABLE blog_coms ADD CONSTRAINT FK_B2D3B210C39B6CE6 FOREIGN KEY (relation_blog_id) REFERENCES blog (id)');
        $this->addSql('CREATE INDEX IDX_B2D3B210C39B6CE6 ON blog_coms (relation_blog_id)');
        $this->addSql('ALTER TABLE commande CHANGE phone phone VARCHAR(255) NOT NULL, CHANGE adresse1 adresse1 LONGTEXT NOT NULL, CHANGE adresse2 adresse2 LONGTEXT DEFAULT NULL, CHANGE district district VARCHAR(255) DEFAULT NULL, CHANGE zipcode zip_code VARCHAR(255) NOT NULL, CHANGE prix_c prix DOUBLE PRECISION NOT NULL');
        $this->addSql('ALTER TABLE commande_item DROP FOREIGN KEY FK_747724FDF347EFB');
        $this->addSql('DROP INDEX IDX_747724FDF347EFB ON commande_item');
        $this->addSql('ALTER TABLE commande_item ADD relation_produit_id INT NOT NULL, ADD quantite INT NOT NULL, DROP produit_id, DROP quantite_c');
        $this->addSql('ALTER TABLE commande_item ADD CONSTRAINT FK_747724FDE524A4E2 FOREIGN KEY (relation_produit_id) REFERENCES produit (id)');
        $this->addSql('CREATE INDEX IDX_747724FDE524A4E2 ON commande_item (relation_produit_id)');
        $this->addSql('ALTER TABLE image CHANGE nom_i nom VARCHAR(255) NOT NULL');
        $this->addSql('ALTER TABLE panier DROP FOREIGN KEY FK_24CC0DF2F347EFB');
        $this->addSql('DROP INDEX IDX_24CC0DF2F347EFB ON panier');
        $this->addSql('ALTER TABLE panier ADD quantite INT NOT NULL, DROP produit_id, DROP quantite_p');
        $this->addSql('ALTER TABLE produit DROP FOREIGN KEY FK_29A5EC27A21214B7');
        $this->addSql('DROP INDEX IDX_29A5EC27A21214B7 ON produit');
        $this->addSql('ALTER TABLE produit ADD relation_categories_id INT NOT NULL, ADD date_ajout DATETIME NOT NULL, ADD stock INT NOT NULL, DROP categories_id, DROP date_ajout_p, DROP stock_p, CHANGE titre_p titre VARCHAR(255) NOT NULL, CHANGE prix_p prix DOUBLE PRECISION NOT NULL, CHANGE description_p description LONGTEXT NOT NULL');
        $this->addSql('ALTER TABLE produit ADD CONSTRAINT FK_29A5EC27D785B153 FOREIGN KEY (relation_categories_id) REFERENCES categories (id)');
        $this->addSql('CREATE INDEX IDX_29A5EC27D785B153 ON produit (relation_categories_id)');
    }

    public function down(Schema $schema): void
    {
        // this down() migration is auto-generated, please modify it to your needs
        $this->addSql('DROP TABLE cgu');
        $this->addSql('DROP TABLE cgv');
        $this->addSql('DROP TABLE contact');
        $this->addSql('ALTER TABLE blog CHANGE date date_b DATETIME NOT NULL, CHANGE titre titre_b VARCHAR(255) CHARACTER SET utf8mb4 NOT NULL COLLATE `utf8mb4_unicode_ci`');
        $this->addSql('ALTER TABLE blog_coms DROP FOREIGN KEY FK_B2D3B210C39B6CE6');
        $this->addSql('DROP INDEX IDX_B2D3B210C39B6CE6 ON blog_coms');
        $this->addSql('ALTER TABLE blog_coms CHANGE relation_blog_id blog_id INT NOT NULL, CHANGE contenu contenu_bc LONGTEXT CHARACTER SET utf8mb4 NOT NULL COLLATE `utf8mb4_unicode_ci`, CHANGE date date_bc DATETIME NOT NULL');
        $this->addSql('ALTER TABLE blog_coms ADD CONSTRAINT FK_B2D3B210DAE07E97 FOREIGN KEY (blog_id) REFERENCES blog (id)');
        $this->addSql('CREATE INDEX IDX_B2D3B210DAE07E97 ON blog_coms (blog_id)');
        $this->addSql('ALTER TABLE commande CHANGE phone phone INT NOT NULL, CHANGE adresse1 adresse1 VARCHAR(255) CHARACTER SET utf8mb4 NOT NULL COLLATE `utf8mb4_unicode_ci`, CHANGE adresse2 adresse2 VARCHAR(255) CHARACTER SET utf8mb4 DEFAULT NULL COLLATE `utf8mb4_unicode_ci`, CHANGE district district VARCHAR(255) CHARACTER SET utf8mb4 NOT NULL COLLATE `utf8mb4_unicode_ci`, CHANGE zip_code zipcode VARCHAR(255) CHARACTER SET utf8mb4 NOT NULL COLLATE `utf8mb4_unicode_ci`, CHANGE prix prix_c DOUBLE PRECISION NOT NULL');
        $this->addSql('ALTER TABLE commande_item DROP FOREIGN KEY FK_747724FDE524A4E2');
        $this->addSql('DROP INDEX IDX_747724FDE524A4E2 ON commande_item');
        $this->addSql('ALTER TABLE commande_item ADD produit_id INT NOT NULL, ADD quantite_c INT NOT NULL, DROP relation_produit_id, DROP quantite');
        $this->addSql('ALTER TABLE commande_item ADD CONSTRAINT FK_747724FDF347EFB FOREIGN KEY (produit_id) REFERENCES produit (id)');
        $this->addSql('CREATE INDEX IDX_747724FDF347EFB ON commande_item (produit_id)');
        $this->addSql('ALTER TABLE image CHANGE nom nom_i VARCHAR(255) CHARACTER SET utf8mb4 NOT NULL COLLATE `utf8mb4_unicode_ci`');
        $this->addSql('ALTER TABLE panier ADD quantite_p INT NOT NULL, CHANGE quantite produit_id INT NOT NULL');
        $this->addSql('ALTER TABLE panier ADD CONSTRAINT FK_24CC0DF2F347EFB FOREIGN KEY (produit_id) REFERENCES produit (id)');
        $this->addSql('CREATE INDEX IDX_24CC0DF2F347EFB ON panier (produit_id)');
        $this->addSql('ALTER TABLE produit DROP FOREIGN KEY FK_29A5EC27D785B153');
        $this->addSql('DROP INDEX IDX_29A5EC27D785B153 ON produit');
        $this->addSql('ALTER TABLE produit ADD categories_id INT NOT NULL, ADD date_ajout_p DATE NOT NULL, ADD stock_p INT NOT NULL, DROP relation_categories_id, DROP date_ajout, DROP stock, CHANGE titre titre_p VARCHAR(255) CHARACTER SET utf8mb4 NOT NULL COLLATE `utf8mb4_unicode_ci`, CHANGE prix prix_p DOUBLE PRECISION NOT NULL, CHANGE description description_p LONGTEXT CHARACTER SET utf8mb4 NOT NULL COLLATE `utf8mb4_unicode_ci`');
        $this->addSql('ALTER TABLE produit ADD CONSTRAINT FK_29A5EC27A21214B7 FOREIGN KEY (categories_id) REFERENCES categories (id)');
        $this->addSql('CREATE INDEX IDX_29A5EC27A21214B7 ON produit (categories_id)');
    }
}
