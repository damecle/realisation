<?php

namespace App\Entity;

use App\Repository\ImageRepository;
use Doctrine\Common\Collections\ArrayCollection;
use Doctrine\Common\Collections\Collection;
use Doctrine\ORM\Mapping as ORM;

/**
 * @ORM\Entity(repositoryClass=ImageRepository::class)
 */
class Image
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
    private $Nom;

    /**
     * @ORM\OneToMany(targetEntity=Produit::class, mappedBy="image", orphanRemoval=true)
     */
    private $relation_produit;

    /**
     * @ORM\OneToMany(targetEntity=Blog::class, mappedBy="relation_image", orphanRemoval=true)
     */
    private $blogs;

    public function __construct()
    {
        $this->relation_produit = new ArrayCollection();
        $this->blogs = new ArrayCollection();
    }

    public function getId(): ?int
    {
        return $this->id;
    }

    public function getNom(): ?string
    {
        return $this->Nom;
    }

    public function setNom(string $Nom): self
    {
        $this->Nom = $Nom;

        return $this;
    }

    /**
     * @return Collection|Produit[]
     */
    public function getRelationProduit(): Collection
    {
        return $this->relation_produit;
    }

    public function addRelationProduit(Produit $relationProduit): self
    {
        if (!$this->relation_produit->contains($relationProduit)) {
            $this->relation_produit[] = $relationProduit;
            $relationProduit->setImage($this);
        }

        return $this;
    }

    public function removeRelationProduit(Produit $relationProduit): self
    {
        if ($this->relation_produit->removeElement($relationProduit)) {
            // set the owning side to null (unless already changed)
            if ($relationProduit->getImage() === $this) {
                $relationProduit->setImage(null);
            }
        }

        return $this;
    }

    /**
     * @return Collection|Blog[]
     */
    public function getBlogs(): Collection
    {
        return $this->blogs;
    }

    public function addBlog(Blog $blog): self
    {
        if (!$this->blogs->contains($blog)) {
            $this->blogs[] = $blog;
            $blog->setRelationImage($this);
        }

        return $this;
    }

    public function removeBlog(Blog $blog): self
    {
        if ($this->blogs->removeElement($blog)) {
            // set the owning side to null (unless already changed)
            if ($blog->getRelationImage() === $this) {
                $blog->setRelationImage(null);
            }
        }

        return $this;
    }
}
