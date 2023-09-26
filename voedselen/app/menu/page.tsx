import styles from "./page.module.css";
import logo from "../../public/voedselen.png";
import Image from "next/image";
import Link from "next/link";
import { Montserrat, Montserrat_Alternates } from 'next/font/google'
import next from "next";


const montserrat = Montserrat_Alternates({
    weight: '400',
    subsets: ['latin']
})

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
        <Link className={styles.link} href={"/"}>Home</Link> <br />
        <Link className={styles.link} href={"/menu"}>Menu</Link> <br />
        <Link className={styles.link} href={"/myorder"}>Orders</Link> <br />
      </div>
      <div id={styles.footer_right}>
        <p>Software S3 DB04 </p>
      </div>
    </div>
  );
}

export default function Menu() {
  return (
    <>
      <main className={styles.main}>
        <div className={styles.main_div}>
            <div className={styles.div1}>test</div>
        </div>
      </main>
       
    </>
  );
}
