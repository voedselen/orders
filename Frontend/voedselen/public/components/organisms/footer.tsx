import Link from "next/link";
import styles from "../../styles/organisms/footer.module.css";
import logo from "../../../public/voedselen.png";
import Image from "next/image";

export default function Footer() {
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
  