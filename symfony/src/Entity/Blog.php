<?php

namespace App\Entity;

use App\Repository\BlogRepository;
use Doctrine\Common\Collections\ArrayCollection;
use Doctrine\Common\Collections\Collection;
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
    private $Date;

    /**
     * @ORM\Column(type="text")
     */
    private $Contenu;

    /**
     * @ORM\Column(type="string", length=255)
     */
    private $Titre;

    /**
     * @ORM\ManyToOne(targetEntity=Image::class, inversedBy="blogs")
     * @ORM\JoinColumn(nullable=false)
     */
    private $relation_image;

    /**
     * @ORM\OneToMany(targetEntity=BlogComs::class, mappedBy="relation_blog", orphanRemoval=true)
     */
    private $blogComs;

    public function __construct()
    {
        $this->blogComs = new ArrayCollection();
    }

    public function getId(): ?int
    {
        return $this->id;
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

    public function getContenu(): ?string
    {
        return $this->Contenu;
    }

    public function setContenu(string $Contenu): self
    {
        $this->Contenu = $Contenu;

        return $this;
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

    public function getRelationImage(): ?Image
    {
        return $this->relation_image;
    }

    public function setRelationImage(?Image $relation_image): self
    {
        $this->relation_image = $relation_image;

        return $this;
    }

    /**
     * @return Collection|BlogComs[]
     */
    public function getBlogComs(): Collection
    {
        return $this->blogComs;
    }

    public function addBlogCom(BlogComs $blogCom): self
    {
        if (!$this->blogComs->contains($blogCom)) {
            $this->blogComs[] = $blogCom;
            $blogCom->setRelationBlog($this);
        }

        return $this;
    }

    public function removeBlogCom(BlogComs $blogCom): self
    {
        if ($this->blogComs->removeElement($blogCom)) {
            // set the owning side to null (unless already changed)
            if ($blogCom->getRelationBlog() === $this) {
                $blogCom->setRelationBlog(null);
            }
        }

        return $this;
    }
}
