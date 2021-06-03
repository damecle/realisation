<?php

namespace App\Repository;

use App\Entity\BlogComs;
use Doctrine\Bundle\DoctrineBundle\Repository\ServiceEntityRepository;
use Doctrine\Persistence\ManagerRegistry;

/**
 * @method BlogComs|null find($id, $lockMode = null, $lockVersion = null)
 * @method BlogComs|null findOneBy(array $criteria, array $orderBy = null)
 * @method BlogComs[]    findAll()
 * @method BlogComs[]    findBy(array $criteria, array $orderBy = null, $limit = null, $offset = null)
 */
class BlogComsRepository extends ServiceEntityRepository
{
    public function __construct(ManagerRegistry $registry)
    {
        parent::__construct($registry, BlogComs::class);
    }

    // /**
    //  * @return BlogComs[] Returns an array of BlogComs objects
    //  */
    /*
    public function findByExampleField($value)
    {
        return $this->createQueryBuilder('b')
            ->andWhere('b.exampleField = :val')
            ->setParameter('val', $value)
            ->orderBy('b.id', 'ASC')
            ->setMaxResults(10)
            ->getQuery()
            ->getResult()
        ;
    }
    */

    /*
    public function findOneBySomeField($value): ?BlogComs
    {
        return $this->createQueryBuilder('b')
            ->andWhere('b.exampleField = :val')
            ->setParameter('val', $value)
            ->getQuery()
            ->getOneOrNullResult()
        ;
    }
    */
}
