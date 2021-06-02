<?php

namespace App\Entity;

use App\Repository\CommandeRepository;
use Doctrine\Common\Collections\ArrayCollection;
use Doctrine\Common\Collections\Collection;
use Doctrine\ORM\Mapping as ORM;

/**
 * @ORM\Entity(repositoryClass=CommandeRepository::class)
 */
class Commande
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
    private $FirstName;

    /**
     * @ORM\Column(type="string", length=255)
     */
    private $LastName;

    /**
     * @ORM\Column(type="string", length=255, nullable=true)
     */
    private $CompagnyName;

    /**
     * @ORM\Column(type="string", length=255)
     */
    private $Phone;

    /**
     * @ORM\Column(type="string", length=255)
     */
    private $Email;

    /**
     * @ORM\Column(type="string", length=255)
     */
    private $Country;

    /**
     * @ORM\Column(type="text")
     */
    private $Adresse1;

    /**
     * @ORM\Column(type="text", nullable=true)
     */
    private $Adresse2;

    /**
     * @ORM\Column(type="string", length=255)
     */
    private $City;

    /**
     * @ORM\Column(type="string", length=255, nullable=true)
     */
    private $District;

    /**
     * @ORM\Column(type="string", length=255)
     */
    private $ZipCode;

    /**
     * @ORM\Column(type="float")
     */
    private $Prix;

    /**
     * @ORM\Column(type="string", length=255)
     */
    private $MethodePaiement;

    /**
     * @ORM\Column(type="datetime")
     */
    private $DateCommande;

    /**
     * @ORM\Column(type="string", length=255)
     */
    private $Status;

    /**
     * @ORM\OneToMany(targetEntity=CommandeItem::class, mappedBy="commande", orphanRemoval=true)
     */
    private $relation_commandeItem;

    public function __construct()
    {
        $this->relation_commandeItem = new ArrayCollection();
    }

    public function getId(): ?int
    {
        return $this->id;
    }

    public function getFirstName(): ?string
    {
        return $this->FirstName;
    }

    public function setFirstName(string $FirstName): self
    {
        $this->FirstName = $FirstName;

        return $this;
    }

    public function getLastName(): ?string
    {
        return $this->LastName;
    }

    public function setLastName(string $LastName): self
    {
        $this->LastName = $LastName;

        return $this;
    }

    public function getCompagnyName(): ?string
    {
        return $this->CompagnyName;
    }

    public function setCompagnyName(?string $CompagnyName): self
    {
        $this->CompagnyName = $CompagnyName;

        return $this;
    }

    public function getPhone(): ?string
    {
        return $this->Phone;
    }

    public function setPhone(string $Phone): self
    {
        $this->Phone = $Phone;

        return $this;
    }

    public function getEmail(): ?string
    {
        return $this->Email;
    }

    public function setEmail(string $Email): self
    {
        $this->Email = $Email;

        return $this;
    }

    public function getCountry(): ?string
    {
        return $this->Country;
    }

    public function setCountry(string $Country): self
    {
        $this->Country = $Country;

        return $this;
    }

    public function getAdresse1(): ?string
    {
        return $this->Adresse1;
    }

    public function setAdresse1(string $Adresse1): self
    {
        $this->Adresse1 = $Adresse1;

        return $this;
    }

    public function getAdresse2(): ?string
    {
        return $this->Adresse2;
    }

    public function setAdresse2(?string $Adresse2): self
    {
        $this->Adresse2 = $Adresse2;

        return $this;
    }

    public function getCity(): ?string
    {
        return $this->City;
    }

    public function setCity(string $City): self
    {
        $this->City = $City;

        return $this;
    }

    public function getDistrict(): ?string
    {
        return $this->District;
    }

    public function setDistrict(?string $District): self
    {
        $this->District = $District;

        return $this;
    }

    public function getZipCode(): ?string
    {
        return $this->ZipCode;
    }

    public function setZipCode(string $ZipCode): self
    {
        $this->ZipCode = $ZipCode;

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

    public function getMethodePaiement(): ?string
    {
        return $this->MethodePaiement;
    }

    public function setMethodePaiement(string $MethodePaiement): self
    {
        $this->MethodePaiement = $MethodePaiement;

        return $this;
    }

    public function getDateCommande(): ?\DateTimeInterface
    {
        return $this->DateCommande;
    }

    public function setDateCommande(\DateTimeInterface $DateCommande): self
    {
        $this->DateCommande = $DateCommande;

        return $this;
    }

    public function getStatus(): ?string
    {
        return $this->Status;
    }

    public function setStatus(string $Status): self
    {
        $this->Status = $Status;

        return $this;
    }

    /**
     * @return Collection|CommandeItem[]
     */
    public function getRelationCommandeItem(): Collection
    {
        return $this->relation_commandeItem;
    }

    public function addRelationCommandeItem(CommandeItem $relationCommandeItem): self
    {
        if (!$this->relation_commandeItem->contains($relationCommandeItem)) {
            $this->relation_commandeItem[] = $relationCommandeItem;
            $relationCommandeItem->setCommande($this);
        }

        return $this;
    }

    public function removeRelationCommandeItem(CommandeItem $relationCommandeItem): self
    {
        if ($this->relation_commandeItem->removeElement($relationCommandeItem)) {
            // set the owning side to null (unless already changed)
            if ($relationCommandeItem->getCommande() === $this) {
                $relationCommandeItem->setCommande(null);
            }
        }

        return $this;
    }
}
