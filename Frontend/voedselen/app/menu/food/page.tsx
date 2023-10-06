import Link from "next/link";
import styles from "./page.module.css";
import Image from "next/image";
import breakfast from "../../../public/menu_breakfast.jpg";
import lunch from "../../../public/menu_lunch.jpg";
import dinner from "../../../public/menu_dinner.jpg";

 import Menucard from "@/public/components/molecules/menucard";

export default function Food() {
  return (
    <>
   
      <main className={styles.main}>
      
        <div className={styles.main_div}>
        <Link className={styles.link} href={"/menu"}>Back</Link>
        <Menucard href={"/menu/food/breakfast"} >
          <Image id={styles.menucard_image} src={breakfast} alt={"breakfast"}></Image>
          <div className={styles.menucard_text}>Breakfast</div>
          </Menucard>   
        <Menucard href={"/menu/food/lunch"} >
          <Image id={styles.menucard_image} src={lunch} alt={"lunch"}></Image>
          <div className={styles.menucard_text}>Lunch</div>
          </Menucard>   
        <Menucard href={"/menu/food/dinner"} >
          <Image id={styles.menucard_image} src={dinner} alt={"dinner"}></Image>
          <div className={styles.menucard_text}>Dinner</div>
          </Menucard>   
        </div>
      </main>
    </>
  );
}
