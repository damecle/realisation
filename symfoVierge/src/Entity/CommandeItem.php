<?php

namespace App\Entity;

use App\Repository\CommandeItemRepository;
use Doctrine\ORM\Mapping as ORM;

/**
 * @ORM\Entity(repositoryClass=CommandeItemRepository::class)
 */
class CommandeItem
{
    /**
     * @ORM\Id
     * @ORM\GeneratedValue
     * @ORM\Column(type="integer")
     */
    private $id;

    /**
     * @ORM\Column(type="integer", nullable=true)
     */
    private $quantiteC;

    /**
     * @ORM\Column(type="float", nullable=true)
     */
    private $prixUnitaire;

    public function getId(): ?int
    {
        return $this->id;
    }

    public function getQuantiteC(): ?int
    {
        return $this->quantiteC;
    }

    public function setQuantiteC(?int $quantiteC): self
    {
        $this->quantiteC = $quantiteC;

        return $this;
    }

    public function getPrixUnitaire(): ?float
    {
        return $this->prixUnitaire;
    }

    public function setPrixUnitaire(?float $prixUnitaire): self
    {
        $this->prixUnitaire = $prixUnitaire;

        return $this;
    }
}
