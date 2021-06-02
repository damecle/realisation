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
    private $Contenu;

    /**
     * @ORM\Column(type="datetime")
     */
    private $Date;

    /**
     * @ORM\ManyToOne(targetEntity=Blog::class, inversedBy="blogComs")
     * @ORM\JoinColumn(nullable=false)
     */
    private $relation_blog;

    public function getId(): ?int
    {
        return $this->id;
    }

    public function getContenu(): ?string
    {
        return $this->Contenu;
    }

    public function setContenu(string $Contenu): self
    {
        $this->Contenu = $Contenu;

        return $this;
    }

    public function getDate(): ?\DateTimeInterface
    {
        return $this->Date;
    }

    public function setDate(\DateTimeInterface $Date): self
    {
        $this->Date = $Date;

        return $this;
    }

    public function getRelationBlog(): ?Blog
    {
        return $this->relation_blog;
    }

    public function setRelationBlog(?Blog $relation_blog): self
    {
        $this->relation_blog = $relation_blog;

        return $this;
    }
}
