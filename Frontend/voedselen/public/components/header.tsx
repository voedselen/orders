import Link from "next/link";
import styles from "../styles/header.module.css";
import logo from "../../public/voedselen.png";
import Image from "next/image";


export default function Header() {
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
  