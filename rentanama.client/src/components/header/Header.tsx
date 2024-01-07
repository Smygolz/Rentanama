import React from "react";
import styles from "./Header.module.css";
import logo from "../../assets/house.svg";
import { Typography, Button } from "@mui/material";

const Header: React.FC = () => {
  return (
    <header className={styles.headerContainer}>
      <div className={styles.logoContainer}>
        <img src={logo} alt="Logo" className={styles.logo} />
      </div>
      <Typography variant="h4" className={styles.logoText}>
        Rentanama
      </Typography>

      <nav className={styles.navContainer}>
        <Button variant="contained" className={styles.navItem}>
          D.U.K
        </Button>
        <Button variant="contained" className={styles.navItem}>
          Registruotis
        </Button>
        <Button variant="contained" className={styles.navItem}>
          Prisijungti
        </Button>
      </nav>
    </header>
  );
};

export default Header;
