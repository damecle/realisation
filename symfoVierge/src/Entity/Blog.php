<?php

namespace App\Entity;

use App\Repository\BlogRepository;
use Doctrine\ORM\Mapping as ORM;

/**
 * @ORM\Entity(repositoryClass=BlogRepository::class)
 */
class Blog
{
    /**
     * @ORM\Id
     * @ORM\GeneratedValue
     * @ORM\Column(type="integer")
     */
    private $id;

    /**
     * @ORM\Column(type="datetime")
     */
    private $dateB;

    /**
     * @ORM\Column(type="text")
     */
    private $contenu;

    /**
     * @ORM\Column(type="string", length=255)
     */
    private $titreB;

    public function getId(): ?int
    {
        return $this->id;
    }

    public function getDateB(): ?\DateTimeInterface
    {
        return $this->dateB;
    }

    public function setDateB(\DateTimeInterface $dateB): self
    {
        $this->dateB = $dateB;

        return $this;
    }

    public function getContenu(): ?string
    {
        return $this->contenu;
    }

    public function setContenu(string $contenu): self
    {
        $this->contenu = $contenu;

        return $this;
    }

    public function getTitreB(): ?string
    {
        return $this->titreB;
    }

    public function setTitreB(string $titreB): self
    {
        $this->titreB = $titreB;

        return $this;
    }
}
