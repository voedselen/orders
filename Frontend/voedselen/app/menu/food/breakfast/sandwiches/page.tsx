import MenuCard from "@/public/components/molecules/menucard";
import styles from "./page.module.css";
import Link from "next/link";

export default function Sandwiches() {
  return (
    <>
      <Link href={"/menu/food/breakfast"}>Back</Link>
      <main className={styles.main}>
        <h1>Sandwiches</h1>
      </main>
    </>
  );
}
