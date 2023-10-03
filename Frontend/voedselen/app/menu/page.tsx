import styles from "./page.module.css";
import logo from "../../public/voedselen.png";
import food from "../../public/menu_food.jpg";
import drinks from "../../public/menu_drinks.jpg";
import Image from "next/image";
import Link from "next/link";
import { Montserrat, Montserrat_Alternates } from "next/font/google";
import next from "next";
import React, { ReactNode } from "react";
import MenuCard from "@/public/components/menucard";

const montserrat = Montserrat_Alternates({
  weight: "400",
  subsets: ["latin"],
});




 

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
