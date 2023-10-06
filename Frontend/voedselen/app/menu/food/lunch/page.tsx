import MenuCard from "@/public/components/molecules/menucard";
import Link from "next/link";
import Image from "next/image";
import styles from "./page.module.css";
import sandwich from "../../../../public/menu_breakfast_sandwich.jpg";
export default function Lunch() {
    return (
        <>
        <main className={styles.main_div}>
            <Link className={styles.link} href={"/menu/food"}>Back</Link>
            <MenuCard href={"/menu/food/lunch/sandwiches"}  >
            <Image id={styles.menucard_image} src={sandwich} alt={"sandwich"}></Image>
            <div className={styles.menucard_text}>Sandwiches</div>
            </MenuCard>

            <MenuCard href={"/menu/food/lunch"}   >
            <Image id={styles.menucard_image} src={sandwich} alt={"sandwich"}></Image>
            <div className={styles.menucard_text}>Soups</div>
            </MenuCard>
        </main>
        </>
    )
}