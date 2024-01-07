import React from "react";
import styles from "./Footer.module.css";
import { Typography } from "@mui/material";

const Footer: React.FC = () => {
  const currentYear = new Date().getFullYear();

  return (
    <footer className={styles.footerContainer}>
      <Typography variant="h6" className={styles.footerText}>
        © {currentYear} T120B165 Saitynai taikomųjų programų projektavimas
      </Typography>
    </footer>
  );
};

export default Footer;
