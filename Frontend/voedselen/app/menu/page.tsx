import styles from "./page.module.css";
import logo from "../../public/voedselen.png";
import food from "../../public/menu_food.jpg";
import drinks from "../../public/menu_drinks.jpg";
import Image from "next/image";
import Link from "next/link";
import { Montserrat, Montserrat_Alternates } from "next/font/google";
import next from "next";
import React, { ReactNode } from "react";

const montserrat = Montserrat_Alternates({
  weight: "400",
  subsets: ["latin"],
});

export function Header() {
  return (
    <div id={styles.header_wrapper}>
      <div id={styles.header_left}>
        <Image id={styles.logo} src={logo} alt={"logo"}></Image>
      </div>
      <div className={styles.header_center}>
        <Link className={styles.header_link} href={"/"}>
          Home
        </Link>
        <Link className={styles.header_link} href={"/menu"}>
          Menu
        </Link>
        <Link className={styles.header_link} href={"/myorders"}>
          Orders
        </Link>
        <Link className={styles.header_link} href={"/reservation"}>
          Reservations
        </Link>
      </div>
      <div id={styles.header_right}>rightside </div>
    </div>
  );
}

export function Footer() {
  return (
    <div id={styles.footer_wrapper}>
      <div id={styles.footer_left}>
        <Image id={styles.logo} src={logo} alt={"logo"}></Image>
      </div>
      <div id={styles.footer_center}>
        <p>
          Voedselen App <br />
        </p>
        <Link className={styles.link} href={"/"}>
          Home
        </Link>{" "}
        <br />
        <Link className={styles.link} href={"/menu"}>
          Menu
        </Link>{" "}
        <br />
        <Link className={styles.link} href={"/myorder"}>
          Orders
        </Link>{" "}
        <br />
      </div>
      <div id={styles.footer_right}>
        <p>Software S3 DB04 </p>
        <br />
        <Link className={styles.link} href={"/reservation"}>
          Make a Reservation
        </Link>{" "}
        <br />
      </div>
    </div>
  );
}

interface MenuCardProps {
  href: string; // Add href prop
  children: ReactNode;
}

export function MenuCard({ href, children }: MenuCardProps) {
  return (
    <Link href={href}>
      <div className={styles.menucard_wrapper}>{children}</div>
    </Link>
  );
}
 

export default function Menu() {
  return (
    <>
      <main className={styles.main}>
        <div className={styles.main_div}>
          <MenuCard href={"/menu/food"}>
            <Image id={styles.menucard_image} src={food} alt={"food"}></Image>
            <div className={styles.menucard_text}>Food</div>
          </MenuCard>
          <MenuCard href={"/menu/drinks"}>
            <Image
              id={styles.menucard_image}
              src={drinks}
              alt={"drinks"}
            ></Image>
            <div className={styles.menucard_text}>Drinks</div>
          </MenuCard>
          
        </div>
      </main>
    </>
  );
}
