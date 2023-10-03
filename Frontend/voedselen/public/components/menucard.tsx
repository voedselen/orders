import Link from "next/link";
import React, { ReactNode } from "react";
import styles from '../styles/menucard.module.css';


interface MenuCardProps {
    href: string; // Add href prop
    children: ReactNode;
  }
  
  export  default function MenuCard({ href, children }: MenuCardProps) {
    return (
      <Link href={href}>
        <div className={styles.menucard_wrapper}>{children}</div>
      </Link>
    );
  }