<?php

namespace App\Entity;

use App\Repository\BlogComsRepository;
use Doctrine\ORM\Mapping as ORM;

/**
 * @ORM\Entity(repositoryClass=BlogComsRepository::class)
 */
class BlogComs
{
    /**
     * @ORM\Id
     * @ORM\GeneratedValue
     * @ORM\Column(type="integer")
     */
    private $id;

    /**
     * @ORM\Column(type="text")
     */
    private $contenuBC;

    /**
     * @ORM\Column(type="datetime")
     */
    private $dateBC;

    public function getId(): ?int
    {
        return $this->id;
    }

    public function getContenuBC(): ?string
    {
        return $this->contenuBC;
    }

    public function setContenuBC(string $contenuBC): self
    {
        $this->contenuBC = $contenuBC;

        return $this;
    }

    public function getDateBC(): ?\DateTimeInterface
    {
        return $this->dateBC;
    }

    public function setDateBC(\DateTimeInterface $dateBC): self
    {
        $this->dateBC = $dateBC;

        return $this;
    }
}
