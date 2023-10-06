import styles from "../../../public/styles/molecules/productcard.module.css";
import { Button } from "../atoms/button.atom";
export default function ProductCard() {
  return (
    <>
      <div className={styles.wrapper_div}>
        <div className={styles.top_image}></div>
        <div className={styles.bottom_section}>
          <div id={styles.bottom_section_text}>
            <div id={styles.product_name}>Product Name</div>
            <div id={styles.product_description}>Product Description</div>
          </div>
          <Button id={styles.bottom_button} theme={"dark"} size={"large"}>
            Add to cart
          </Button>
        </div>
      </div>
    </>
  );
}
