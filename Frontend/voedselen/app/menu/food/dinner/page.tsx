import Link from "next/link";
import styles from "./page.module.css";
import ProductCard from "@/public/components/molecules/productcard";

export default function Dinner() {
  return (
    <>
      <main>
        <Link className={styles.link} href={"/menu/food"}>
          Back
        </Link>
        <ProductCard></ProductCard>
      </main>
    </>
  );
}
