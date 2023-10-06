import MenuCard from "@/public/components/molecules/menucard";
import styles from "./page.module.css";
import beer from "../../../public/menu_drinks_beer.jpg";
import wine from "../../../public/menu_drinks_wine.jpg";
import soda from "../../../public/menu_drinks_soda.jpg";
import cocktails from "../../../public/menu_drinks_cocktail.jpg";
import hotdrinks from "../../../public/menu_drinks_hot.jpg";
import Image from "next/image";
export default function Drinks() {
  return (
    <>
      <main className={styles.main}>
        <div className={styles.main_div}>
          <MenuCard href={"/menu/drinks/beer"}>
            <Image
              id={styles.menucard_image}
              src={beer}
              alt={"beer"}
            ></Image>
            <div className={styles.menucard_text}>Beer</div>
          </MenuCard>
          <MenuCard href={"/menu/drinks/cocktails"}>
            <Image
              id={styles.menucard_image}
              src={cocktails}
              alt={"sandwich"}
            ></Image>
            <div className={styles.menucard_text}>Cocktails</div>
          </MenuCard>
          <MenuCard href={"/menu/drinks/hotdrinks"}>
            <Image
              id={styles.menucard_image}
              src={hotdrinks}
              alt={"sandwich"}
            ></Image>
            <div className={styles.menucard_text}>Hot drinks</div>
          </MenuCard>
          <MenuCard href={"/menu/drinks/soda"}>
            <Image
              id={styles.menucard_image}
              src={soda}
              alt={"sandwich"}
            ></Image>
            <div className={styles.menucard_text}>Soda</div>
          </MenuCard>
          <MenuCard href={"/menu/drinks/wine"}>
            <Image
              id={styles.menucard_image}
              src={wine}
              alt={"sandwich"}
            ></Image>
            <div className={styles.menucard_text}>Wine</div>
          </MenuCard>
        </div>
      </main>
    </>
  );
}
