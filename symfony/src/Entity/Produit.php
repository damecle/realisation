<?php

namespace App\Entity;

use App\Repository\ProduitRepository;
use Doctrine\Common\Collections\ArrayCollection;
use Doctrine\Common\Collections\Collection;
use Doctrine\ORM\Mapping as ORM;

/**
 * @ORM\Entity(repositoryClass=ProduitRepository::class)
 */
class Produit
{
    /**
     * @ORM\Id
     * @ORM\GeneratedValue
     * @ORM\Column(type="integer")
     */
    private $id;

    /**
     * @ORM\Column(type="string", length=255)
     */
    private $Titre;

    /**
     * @ORM\Column(type="float")
     */
    private $Prix;

    /**
     * @ORM\Column(type="text")
     */
    private $Description;

    /**
     * @ORM\Column(type="datetime")
     */
    private $Date_ajout;

    /**
     * @ORM\Column(type="integer")
     */
    private $Stock;

    /**
     * @ORM\ManyToOne(targetEntity=Image::class, inversedBy="relation_produit")
     * @ORM\JoinColumn(nullable=false)
     */
    private $image;

    /**
     * @ORM\ManyToOne(targetEntity=Categories::class, inversedBy="produits")
     * @ORM\JoinColumn(nullable=false)
     */
    private $relation_categories;

    /**
     * @ORM\OneToMany(targetEntity=CommandeItem::class, mappedBy="relation_produit", orphanRemoval=true)
     */
    private $commandeItems;

    public function __construct()
    {
        $this->commandeItems = new ArrayCollection();
    }

    public function getId(): ?int
    {
        return $this->id;
    }

    public function getTitre(): ?string
    {
        return $this->Titre;
    }

    public function setTitre(string $Titre): self
    {
        $this->Titre = $Titre;

        return $this;
    }

    public function getPrix(): ?float
    {
        return $this->Prix;
    }

    public function setPrix(float $Prix): self
    {
        $this->Prix = $Prix;

        return $this;
    }

    public function getDescription(): ?string
    {
        return $this->Description;
    }

    public function setDescription(string $Description): self
    {
        $this->Description = $Description;

        return $this;
    }

    public function getDateAjout(): ?\DateTimeInterface
    {
        return $this->Date_ajout;
    }

    public function setDateAjout(\DateTimeInterface $Date_ajout): self
    {
        $this->Date_ajout = $Date_ajout;

        return $this;
    }

    public function getStock(): ?int
    {
        return $this->Stock;
    }

    public function setStock(int $Stock): self
    {
        $this->Stock = $Stock;

        return $this;
    }

    public function getImage(): ?Image
    {
        return $this->image;
    }

    public function setImage(?Image $image): self
    {
        $this->image = $image;

        return $this;
    }

    public function getRelationCategories(): ?Categories
    {
        return $this->relation_categories;
    }

    public function setRelationCategories(?Categories $relation_categories): self
    {
        $this->relation_categories = $relation_categories;

        return $this;
    }

    /**
     * @return Collection|CommandeItem[]
     */
    public function getCommandeItems(): Collection
    {
        return $this->commandeItems;
    }

    public function addCommandeItem(CommandeItem $commandeItem): self
    {
        if (!$this->commandeItems->contains($commandeItem)) {
            $this->commandeItems[] = $commandeItem;
            $commandeItem->setRelationProduit($this);
        }

        return $this;
    }

    public function removeCommandeItem(CommandeItem $commandeItem): self
    {
        if ($this->commandeItems->removeElement($commandeItem)) {
            // set the owning side to null (unless already changed)
            if ($commandeItem->getRelationProduit() === $this) {
                $commandeItem->setRelationProduit(null);
            }
        }

        return $this;
    }
}
