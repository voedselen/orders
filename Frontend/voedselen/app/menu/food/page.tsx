import Link from "next/link";
import styles from "./page.module.css";
import Image from "next/image";
import breakfast from "../../../public/menu_breakfast.jpg";
import lunch from "../../../public/menu_lunch.jpg";
import dinner from "../../../public/menu_dinner.jpg";

export function MenuCardBreakfast() {
  return (
    <Link href={"/menu/food/breakfast"}>
      <div className={styles.menucard_wrapper}>
        <Image
          id={styles.menucard_image}
          src={breakfast}
          alt={"breakfast"}
        ></Image>

        <div className={styles.menucard_text}>Breakfast</div>
      </div>
    </Link>
  );
}
export function MenuCardLunch() {
  return (
    <Link href={"/menu/food/lunch"}>
      <div className={styles.menucard_wrapper}>
        <Image
          id={styles.menucard_image}
          src={lunch}
          alt={"lunch"}
        ></Image>

        <div className={styles.menucard_text}>Lunch</div>
      </div>
    </Link>
  );
}
export function MenuCardDinner() {
  return (
    <Link href={"/menu/food/dinner"}>
      <div className={styles.menucard_wrapper}>
        <Image
          id={styles.menucard_image}
          src={dinner}
          alt={"dinner"}
        ></Image>

        <div className={styles.menucard_text}>Dinner</div>
      </div>
    </Link>
  );
}

export default function Food() {
  return (
    <>
      <main className={styles.main}>
        <div className={styles.main_div}>
          <MenuCardBreakfast></MenuCardBreakfast>
            <MenuCardLunch></MenuCardLunch> 
            <MenuCardDinner></MenuCardDinner>          
        </div>
      </main>
    </>
  );
}
