class TurnBasedGame
{
    static void games()
    {

        #region Main Data
        double fixedPlayerHP = 100, fixedMonsterHP = 0, playerHP = 0, monsterHP = 0, action = 0, roll = 0, turn = 1, experienceGiven = 0, critMultiplier = 0, heal = 0; 
        int count = 0, miss = 0, choose = 0, effectDuration = 0, expRequirement = 0, expUP = 0, upTrigger = 0, UPBreak = 0, expNeed = 0, UPCount = 1, defeatedSlime = 0, defeatedGoblin = 0, naturalMissChance = 1;
        string? kata = "", monsterType = "", critPerson = "", healedPerson = "", playerName = "", attackingPerson = "", attackType = "";
        bool evade = false, critSuccess = false, keyPressed = false, evasionSuccess = false, playerWin = true, slimeKingSpawn = false, goblinKingSpawn = false;

        Random dice = new Random();
        #endregion

        #region Attribute
        int level = 0, oppLevel = 0, ATK = 0, DEF = 0, AGI = 0, DEX = 0, CRT = 0, LUK = 0, INT = 0, RES = 0, MP = 0, SP = 0, MaxSP = 5,
            playerLvl = 0, playerATK = 0, playerDEF = 0, playerAGI = 0, playerDEX = 0, playerCRT = 0, playerLUK = 0, playerINT = 0, playerRES = 0, playerMP = 0, playerSP = 0, playerMaxMP = 0,
            monsterLvl = 0, monsterATK = 0, monsterDEF = 0, monsterAGI = 0, monsterDEX = 0, monsterCRT = 0, monsterLUK = 0, monsterINT = 0, monsterRES = 0, monsterMP = 0, monsterSP = 0;
        double playerExp = 0, HP = 0, maxHP = 0, atkPen = 0, dmgReduction = 0, rawDmg = 0, bonusDmg = 0, totalDmg = 0, outputDmg = 0, DEFMulti = 0, blockReduction = 0.6, critChance = 0;
        #endregion
        
        #region Player Welcome
        attributePlayer(); playerMP = 40 + (playerLvl * 5); playerMaxMP = 40 + (playerLvl * 5);

        kata = "Masukkan namamu \nTekan enter untuk menggunakan  (Nama default : Ciel)\n\n";
        typingEffect();

        for (int i = 0; i == 0; i++)
        {

        playerName = Console.ReadLine();
        if (playerName == "") 
            {
                defaultName();
                kata = $"Kamu menggunakan nama default, namamu adalah {playerName}";
                typingEffect();
                continue;
            }
        char[] charName = playerName.ToCharArray(); 
        var capital = charName[0]; var capitalized = capital.ToString().ToUpper();
        var finalName = new string(charName);
        finalName = finalName.Remove(0,1);
        playerName = $"{capitalized}{finalName}";
        kata = $"Input diterima, namamu adalah {playerName}";
        typingEffect();
        }
        
        Thread.Sleep(1200);
        Console.Clear();
        
        experienceSystem();

        playerLvl = 1;
        playerDisplay();
        Console.Clear();

        #endregion

        #region Battle Section

        void Encounter()
        {
        monstertype();
        gameOpening();
        gameClosing();
        }
        
        void pressSection()
        {

            kata = $"\n\n\nTekan apapun untuk melanjutkan";
            typingEffect();

            void KeyPressed()
            {
            Console.ReadKey(true);
            keyPressed = true;
            }

            Thread t = new Thread(KeyPressed);
            t.Start();

            while (!keyPressed)
            {
                for (int i = 1; i <= 1; i++)
                    {
                        for (int a = 1; a <= 3; a++)
                        {
                        Console.Write(".");
                        Thread.Sleep(120);
                        }
                        for (int a = 1; a <= 3; a++)
                        {
                        Console.Write("\b \b");
                        }
                        
                        Thread.Sleep(200);
                    }
            if (keyPressed)
                {break;}
            }

            keyPressed = false;
            Console.Clear();
            battleLoad();
            engageBattle();
        }
        
        void choosingSection()
        {
            playerSP = 0; monsterSP = 0; SP = 0;
            kata = $"\n\nApa yang ingin kamu lakukan?\n\n1. Lawan {monsterType}\n2. Kabur dari {monsterType}\n\n";
            typingEffect();
            input();

            switch (choose)
            {
                case 1:
                kata = $"{playerName} memilih untuk melawan {monsterType}";
                typingEffect();
                break;
                
                case 2:
                kata = $"{playerName} memilih untuk kabur dari {monsterType}\n";
                typingEffect();
                loading();
                Encounter();
                break;
                
                default:
                kata = "Maaf input yang anda masukkan tidak valid";
                typingEffect();
                choosingSection();
                break;
            }
        }

        #endregion



        #region Important

        void experienceSystem()
        {
            if (playerWin)
            {
                int UPComparator = 0;
                UPComparator = playerLvl / 5; playerExp += experienceGiven;
                upTrigger = (playerLvl + 1) % 5; if (upTrigger == 0) {UPBreak++;}

                switch (UPBreak)
                {
                    case 0:
                    expUP = 5;
                    break;

                    case 1:
                    expUP = 40;
                    break;

                    case 2:
                    expUP = 80;
                    break;

                    case 3:
                    expUP = 200;
                    break;

                    case 4:
                    expUP = 400;
                    break;

                    case 5:
                    expUP = 800;
                    break;

                    case 6:
                    break;

                    case 7:
                    break;

                    case 8:
                    break;

                    case 9:
                    break;

                    case 10:
                    break;

                    case 11:
                    break;

                    case 12:
                    break;

                    case 13:
                    break;

                    case 14:
                    break;

                    case 15:
                    break;

                    case 16:
                    break;
                }
                if (UPCount != 0)
                {
                    switch (UPComparator)
                    {
                        case 0:
                        expRequirement += 5; UPCount = 0;
                        break;
                        
                        case 1:
                        expRequirement += 10; UPCount = 0;
                        break;

                        case 2:
                        expRequirement += 20; UPCount = 0;
                        break;

                        case 3:
                        expRequirement += 50; UPCount = 0;
                        break;

                        case 4:
                        expRequirement += 100; UPCount = 0;
                        break;

                        case 5:
                        expRequirement += 200; UPCount = 0;
                        break;

                        case 6:
                        break;

                        case 7:
                        break;

                        case 8:
                        break;

                        case 9:
                        break;

                        case 10:
                        break;

                        case 11:
                        break;

                        case 12:
                        break;

                        case 13:
                        break;

                        case 14:
                        break;

                        case 15:
                        break;

                        case 16:
                        break;
                    }
                    expNeed = expUP + expRequirement;
                    
                    if (playerLvl != 0)
                    {
                    kata = $"Level : {playerLvl} ({playerExp}/{expNeed})\n";
                    typingEffect();
                    }
                }
                
                if (playerExp >= expNeed && playerLvl != 0)
                {
                    playerExp -= expNeed;
                    playerLvl++;
                    UPCount++;
                    
                    kata = $"\nKamu berhasil Level UP ke level {playerLvl} dari level {playerLvl - 1}!\n";
                    typingEffect();
                    
                    if (playerLvl % 5 == 0) 
                    {
                        expRequirement = 0;
                        fixedPlayerHP += 5;
                        kata = $"\nKamu berhasil melakukan level break!\nHP mu bertambah 5 poin dari {fixedPlayerHP - 5} HP ke {fixedPlayerHP} HP\n";
                        typingEffect();
                    }

                    Thread.Sleep(1600);
                }

                Console.Clear();
            }
        }

        void defaultName()
        {
            playerName = "Ciel";
        }

        void playerDisplay()
        {   
            loading();
            attributePlayer();
            kata = $"Selamat datang {playerName}\nAtribut {playerName} :\n\nLevel : {playerLvl} ({playerExp}/{expNeed})\n\nMax HP : {fixedPlayerHP} HP\nMax MP : {playerMP} MP\n\nATK : {playerATK}\nDEF : {playerDEF}\nAGI : {playerAGI}\nDEX : {playerDEX}\nCRT : {playerCRT}\nLUK : {playerLUK}";
            typingEffect();
            
            kata = $"\n\n\nTekan apapun untuk melanjutkan";
            typingEffect();
            
            void KeyPressed()
            {
            Console.ReadKey(true);
            keyPressed = true;
            }

            Thread t = new Thread(KeyPressed);
            t.Start();

            while (!keyPressed)
            {
                for (int i = 1; i <= 1; i++)
                    {
                        for (int a = 1; a <= 3; a++)
                        {
                        Console.Write(".");
                        Thread.Sleep(120);
                        }
                        for (int a = 1; a <= 3; a++)
                        {
                        Console.Write("\b \b");
                        }
                        
                        Thread.Sleep(200);
                    }
            if (keyPressed)
                {break;}
            }

            keyPressed = false;
            Console.Clear();
            Encounter();
        }

        void monsterDisplay()
        {
            attributeMonster();
            kata = $"Atribut {monsterType} :\n\nLevel : {monsterLvl}\n\nMax HP : {fixedMonsterHP}\nMax MP : {monsterMP}\n\nATK : {monsterATK}\nDEF : {monsterDEF}\nAGI : {monsterAGI}\nDEX : {monsterDEX}\nCRT : {monsterCRT}\nLUK : {monsterLUK}";
            typingEffect();
            
            choosingSection();
            pressSection();
        }

        void attributePlayer()
        {
            playerATK = 12 + (playerLvl * 2); 
            playerDEF = 9 + (playerLvl * 2);
            playerAGI = 6 + (playerLvl * 3); 
            playerDEX = 4 + (playerLvl * 3); 
            playerCRT = 5 + (playerLvl * 2); 
            playerLUK = 7 + (playerLvl * 3);   

            maxHP = fixedPlayerHP;
            oppLevel = monsterLvl;
            level = playerLvl;
            HP = playerHP;
            ATK = playerATK; 
            DEF = monsterDEF; 
            AGI = monsterAGI; 
            DEX = playerDEX; 
            CRT = playerCRT; 
            LUK = playerLUK; 
            INT = playerINT; 
            RES = monsterRES; 
            MP = playerMP; 
            SP = playerSP;

            critPerson = "Kamu";
        }

        void attributeMonster()
        {
            maxHP = fixedMonsterHP;
            oppLevel = playerLvl;
            level = monsterLvl;
            HP = monsterHP;
            ATK = monsterATK; 
            DEF = playerDEF; 
            AGI = playerAGI; 
            DEX = monsterDEX; 
            CRT = monsterCRT; 
            LUK = monsterLUK; 
            INT = monsterINT; 
            RES = playerRES;
            MP = monsterMP;  
            SP = monsterSP;

            critPerson = monsterType;
        }

        void playerSkillPoints()
        {
            if (evasionSuccess != true)
            {
            playerSP += SP;
            SP = 0;
            if (playerSP >= MaxSP)
                {playerSP = 5;}
            }
        }
        
        void monsterSkillPoints()
        {
            if (evasionSuccess != true)
            {
            monsterSP += SP;
            SP = 0;
            if (monsterSP >= MaxSP)
                {monsterSP = 5;}
            }
        }

        #endregion

        #region Misc

        void monsterAttacked()
        {
            if (evasionSuccess == false)
            {
                monsterHP -= outputDmg;
                if (monsterHP <= 0) monsterHP = 0;
                kata = $"{monsterType} terkena serangan dan kehilangan {outputDmg} nyawa dan sekarang memiliki {monsterHP} nyawa.";
                typingEffect();
            }
        }

        void playerAttacked()
        {
            if (evasionSuccess == false)
            {
                playerHP -= outputDmg;
                if (playerHP <= 0) playerHP = 0;
                kata = $"{playerName}, kamu terkena serangan dan kehilangan {outputDmg} nyawa dan sekarang memiliki {playerHP} nyawa.";
                typingEffect();
            }
        }

        void input()
        {
            ConsoleKeyInfo userInput = Console.ReadKey(true);
            
            choose = int.Parse(userInput.KeyChar.ToString());
        }

        void typingEffect()
        {
            char[] word = kata.ToCharArray();

            foreach(char chara in word)
            {
                Console.Write(word[count]);
                count++;
                Thread.Sleep(1);
            }
            count = 0;
        }

        void gameOpening()
        {
            Thread.Sleep(1000);
            Console.Clear();

            kata = $"Kamu bertemu dengan {monsterType} (Lvl. {monsterLvl}) di tengah perjalanan\nLevelmu saat ini : (Lvl. {playerLvl})\n\n";
            typingEffect();
            monsterDisplay();
            Thread.Sleep(1000);
        }

        void battleLoad()
        {
            Thread.Sleep(800);
            Console.Clear();
            kata = "Mempersiapkan pertarungan\n\n";
            typingEffect();
            
            kata = "Loading";
            typingEffect();
            
            for (int i = 1; i <= 3; i++)
            {
                for (int a = 1; a <= 3; a++)
                {
                Console.Write(".");
                Thread.Sleep(90);
                }
                for (int a = 1; a <= 3; a++)
                {
                Console.Write("\b \b");
                }
                
                Thread.Sleep(300);
            }
            
            for (int a = 0; a <= 3; a++)
            {
                Console.Write(".");
                Thread.Sleep(70);
            }

            Thread.Sleep(500);
            Console.Clear();
        }

        void loading()
        {
            Thread.Sleep(1500);
            Console.Clear();

            tips();

            kata = "Loading";
            typingEffect();
            
            for (int i = 1; i <= 3; i++)
            {
                for (int a = 1; a <= 3; a++)
                {
                Console.Write(".");
                Thread.Sleep(90);
                }
                for (int a = 1; a <= 3; a++)
                {
                Console.Write("\b \b");
                }
                
                Thread.Sleep(200);

                if (i == 1) continue;
            }

            for (int a = 0; a <= 3; a++)
            {
                Console.Write(".");
                Thread.Sleep(70);
            }

            Thread.Sleep(1000);
            Console.Clear();
            
        }

        void playerTurn()
        {
            string[] displayPlayer = {$"HP : {playerHP} HP", $"MP : {playerMP} MP", $"SP : {playerSP} SP"};
            string[] displayMonster = {$"HP : {monsterHP} HP",  $"MP : {monsterMP} MP", $"SP : {monsterSP} SP"};


            Thread.Sleep(1000);
            kata = ($"\n\nTurn : {playerName}\n\n");
            typingEffect();
            
            kata = String.Format("{0,-25} {1,0}\n", $"{playerName} :", $"{monsterType} :");
            typingEffect();
            
            kata = String.Format("{0,-25} {1,0}\n\n", $"Lvl. {playerLvl}", $"Lvl. {monsterLvl}");
            for(int index = 0; index < displayPlayer.Length; index++)
            kata += String.Format("{0,-25} {1,-0}\n",
                displayPlayer[index], displayMonster[index]);

            typingEffect();

            Thread.Sleep(1000);
        }

        void monsterTurn()
        {
            Thread.Sleep(1000);
            kata = $"\n\nTurn : {monsterType}\n\n";
            typingEffect();

            Thread.Sleep(1000);
        }

        void nextRound()
        {
            Thread.Sleep(1000);
            Console.Clear();

            kata = "Ronde selanjutnya";
            typingEffect();

            Thread.Sleep(1000);
            Console.Clear();
        }

        void gameRound()
        {
            kata = $"Round : {turn}";
            typingEffect();
        }

        void gameClosing()
        {
            if (playerHP > monsterHP && monsterHP <= 0)
        {
            playerWin = true; defeatedMonsterCheck();
            Console.WriteLine(@"______________________________________________________________________________________________");
            Console.WriteLine(@"______________________________________________________________________________________________");
            Console.WriteLine(@"                                                                                              ");
            Console.WriteLine(@" __    __    ________    __       __      __      __      __    ___    ____      ___     ___  ");
            Console.WriteLine(@"|  |  |  |  |   __   |  |  |     |  |    |  |    |  |    |  |  |   |  |    \    |   |   |   | ");
            Console.WriteLine(@"|  |  |  |  |  |  |  |  |  |     |  |    |  |    |  |    |  |  |   |  |     \   |   |   |   | ");
            Console.WriteLine(@"|  |  |  |  |  |  |  |  |  |     |  |    |  |    |  |    |  |  |   |  |      \  |   |   |   | ");
            Console.WriteLine(@" \  \/  /   |  |  |  |  |  |     |  |    |  |    |  |    |  |  |   |  |  |\   \ |   |   |   | ");
            Console.WriteLine(@"  \    /    |  |  |  |  |  |     |  |    |  |    |  |    |  |  |   |  |  |  \  \|   |   |   | ");
            Console.WriteLine(@"   |  |     |  |  |  |  |  |     |  |    |  |    |  |    |  |  |   |  |  |   \  \   |    \_/  ");
            Console.WriteLine(@"   |  |     |  |  |  |  |  |     |  |    \   \  /    \  /   /  |   |  |  |    \     |    ___  ");
            Console.WriteLine(@"   |  |     |  |__|  |   \  \___/  /      \   \/  /\  \/   /   |   |  |  |     \    |   |   | ");
            Console.WriteLine(@"   |__|     |________|    \_______/        \_____/   \____/    |___|  |__|      \___|   |___| ");
            Console.WriteLine(@"                                                                                              ");
            Console.WriteLine(@"______________________________________________________________________________________________");
            Console.WriteLine(@"______________________________________________________________________________________________");
        }
        else if (monsterHP > playerHP && playerHP <= 0)
        {
            playerWin = false;
            Console.WriteLine(@"______________________________________________________________________________________________");
            Console.WriteLine(@"______________________________________________________________________________________________");
            Console.WriteLine(@"                                                                                              ");
            Console.WriteLine(@" __    __    ________    __       __       __           ________     ___________    _________ ");
            Console.WriteLine(@"|  |  |  |  |   __   |  |  |     |  |     |  |         |   __   |   |  _________|  |  _______|");
            Console.WriteLine(@"|  |  |  |  |  |  |  |  |  |     |  |     |  |         |  |  |  |   | |            | |        ");
            Console.WriteLine(@"|  |  |  |  |  |  |  |  |  |     |  |     |  |         |  |  |  |   | |            | |        ");
            Console.WriteLine(@" \  \/  /   |  |  |  |  |  |     |  |     |  |         |  |  |  |   | \________    | |_______ ");
            Console.WriteLine(@"  \    /    |  |  |  |  |  |     |  |     |  |         |  |  |  |   \_________ \   |  _______|");
            Console.WriteLine(@"   |  |     |  |  |  |  |  |     |  |     |  |         |  |  |  |             | |  | |        ");
            Console.WriteLine(@"   |  |     |  |  |  |  |  |     |  |     |  |         |  |  |  |             | |  | |        ");
            Console.WriteLine(@"   |  |     |  |__|  |   \  \___/  /      |  |_____    |  |__|  |    _________| |  | |_______ ");
            Console.WriteLine(@"   |__|     |________|    \_______/       |________|   |________|   |___________|  |_________|");
            Console.WriteLine(@"                                                                                              ");
            Console.WriteLine(@"______________________________________________________________________________________________");
            Console.WriteLine(@"______________________________________________________________________________________________");
        }

        Thread.Sleep(1200);
        Console.Clear();

        if (monsterLvl > playerLvl && playerWin == true) 
        {
            double booster = (monsterLvl - playerLvl) * 5;
            kata = $"Kamu mendapatkan tambahan EXP karena berhasil melawan musuh dengan level diatasmu\nTambahan EXP : {booster}%\n";
            typingEffect();

            booster = booster / 5;

            experienceGiven = Math.Round(experienceGiven + (experienceGiven * (booster / 20)));
            experienceGiven = Math.Truncate(experienceGiven);
        }

        if (playerLvl != 80 && playerWin) 
        {
            kata = $"Kamu mendapatkan {experienceGiven} EXP dari mengalahkan {monsterType}";
            typingEffect();
            Thread.Sleep(700);
            experienceSystem();
        }
        
        if (playerWin == false) 
        {
            playerExp = 0;
            kata = $"\n{playerName} mati terbunuh oleh {monsterType}\nKamu akan dihidupkan kembali namun EXP mu akan kembali ke 0\nLevel {playerName} : {playerLvl} ({playerExp}/{expNeed})\n\n";
            typingEffect();
        }

        Thread.Sleep(2000);
        Console.Clear();

        loading();
        attributePlayer();
        Encounter();
        }

        void tips()
        {
            kata = "Tips :\n\n";

            int i = dice.Next(1,11);

            switch (i)
            {
                case 1:
                kata += $"Kamu berkesempatan untuk bertemu dengan spesies monster yang lebih kuat\njika sudah mengalahkan monster tersebut sebanyak 10x\n\n\n";
                break;

                case 2:
                kata += $"Hati-hati saat menggunakan heavy attack, karena HP mu akan berkurang jika seranganmu meleset\n\n\n";
                break;

                case 3:
                kata += $"Jangan terlalu gegabah dalam memilih musuh, terutama jika levelnya berada diatasmu\n\n\n";
                break;

                case 4:
                kata += $"Setiap pilihanmu akan menuntun kamu ke jalan cerita yang berbeda\n\n\n";
                break;

                case 5:
                kata += $"Ada beberapa skill menarik yang bisa kamu dapatkan di sepanjang perjalananmu\n\n\n";
                break;

                case 6:
                kata += $"Jangan terpaku pada tier untuk menentukan hebat atau tidaknya sesuatu\n\n\n";
                break;

                case 7:
                kata += $"Akan ada banyak hal tak terduga dalam perjalananmu, bersiaplah untuk yang terburuk\n\n\n";
                break;

                case 8:
                kata += $"Terkadang menjadi naif itu adalah pilihan terbaik\n\n\n";
                break;

                case 9:
                kata += $"Selalu waspadai siapapun, kamu tidak akan tau apa yang akan terjadi selanjutnya\n\n\n";
                break;

                case 10:
                kata += $"Kekuatan terkadang bisa membawa kebahagiaan, kehampaan, ataupun kehancuran\n\n\n";
                break;
            }

            typingEffect();
        }

        #endregion

        #region Formula

        void critical()
        {   
            double critRound = Math.Round(critChance);
            int critIn = Convert.ToInt32(critRound), critCompare = 100;
            double critOut = dice.Next(critIn, 101);

            if (critOut == critCompare)
            {
                criticalDamage();
            }
        }

        void criticalChance()
        {
            critChance = Math.Round(LUK / (level * 4 + 40d) * CRT, 1);
            critical();
        }

        void criticalDamage()
        {
            outputDmg = Math.Round(outputDmg * critMultiplier , 0);
            outputDmg = Math.Truncate(outputDmg);
            critSuccess = true;
        }

        void rawDamage()
        {
            switch (roll)
            {
                case 1:
                rawDmg = Math.Round(ATK * 0.7, 1);
                break;

                case 2:
                rawDmg = Math.Round(ATK * 0.75, 1);
                break;

                case 3:
                rawDmg = Math.Round(ATK * 0.8, 1);
                break;

                case 4:
                rawDmg = Math.Round(ATK * 0.85, 1);
                break;

                case 5:
                rawDmg = Math.Round(ATK * 0.9, 1);
                break;

                case 6:
                rawDmg = Math.Round(ATK * 0.95, 1);
                break;

                case 7:
                rawDmg = ATK * 1;
                break;

                case 8:
                rawDmg = Math.Round(ATK * 1.05, 1);
                break;

                case 9:
                rawDmg = Math.Round(ATK * 1.1, 1);
                break;

                case 10:
                rawDmg = Math.Round(ATK * 1.15, 1);
                break;

                case 11:
                rawDmg = Math.Round(ATK * 1.2, 1);
                break;

                case 12:
                rawDmg = Math.Round(ATK * 1.25, 1);
                break;

                case 13:
                rawDmg = Math.Round(ATK * 1.3, 1);
                break;

                case 14:
                rawDmg = Math.Round(ATK * 1.35, 1);
                break;
            }

            rawDmg = Math.Truncate(rawDmg);
            bonusDamage();
        }

        void bonusDamage()
        {
            bonusDmg = Math.Round((ATK + (level * 15)) / 100d, 1);
            bonusDmg = Math.Truncate(bonusDmg);
            totalDamage();
        }

        void totalDamage()
        {
            totalDmg = Math.Round(rawDmg + bonusDmg);
            totalDmg = Math.Truncate(totalDmg);
            defMultiplier();
        }

        void defMultiplier()
        {
            DEFMulti = oppLevel * 3 + DEF;
            outputDamage();
        }
        
        void outputDamage()
        {
            outputDmg = Math.Round((totalDmg / DEFMulti - DEFMulti * atkPen) * 25 * (1 - dmgReduction), 0);
            outputDmg = Math.Truncate(outputDmg);
            criticalChance();
        }

        #endregion

        #region Action

        void engageBattle()
        {
            playerHP = fixedPlayerHP; monsterHP = fixedMonsterHP;
            do
        {   
            gameRound();
            // Giliran player
            playerTurn();
            aksimu();
            Thread.Sleep(1000);
            Console.Clear();

            // Akan berhenti ketika nyawa player mencapai 0
            if (playerHP <= 0 || monsterHP <= 0) continue;
            
            // Giliran monster
            gameRound();
            monsterTurn();
            aksiMonster();
            turn++;

            loading();
            nextRound();

        } while (playerHP > 0 && monsterHP > 0);

        }

        void aksimu()
        {   
            choose = 0; attributePlayer(); attackingPerson = playerName; critSuccess = false; 
            evasionSuccess = false; naturalMissChance = 41; evadeAction();

            kata = $"\n\nApa yang ingin kamu lakukan?\n\n1. Serang {monsterType}\n2. Pulihkan {playerName} (Konsumsi 20 MP)\n3. Tahan Serangan {monsterType}\n4. Hindari Serangan {monsterType}\n\n";
            typingEffect();
            input();
            switch (choose)
            {
            case 1:
            kata = $"\n\n{playerName} memilih untuk menyerang {monsterType}\n\n";
            typingEffect();

            Thread.Sleep(1200);
            attackAction();
            if (action == 3)
            {
                blockAction();
                monsterSkillPoints();
                monsterAttacked();
                Thread.Sleep(500);
            }
            else
            {
                monsterAttacked();
                Thread.Sleep(500);
            }
            break;
            
            case 2:
            maxHP = fixedPlayerHP;
            healedPerson = $"{playerName}";
            if (playerHP < fixedPlayerHP)
            {
                if (MP >= 20)
                    {
                    kata = $"\n\n{playerName} memilih untuk memulihkan diri\n\n";
                    typingEffect();
                    Thread.Sleep(500);
                    healAction();
                    }
                else
                    {
                        kata = "Maaf MP mu tidak mencukupi";
                        typingEffect();
                        aksimu();
                    }
            }
            else
            {
                kata = "Maaf HP mu masih penuh";
                typingEffect();
                aksimu();
            }
            Thread.Sleep(500);
            break;
            
            case 3:
            kata = $"\n\n{playerName} memilih untuk bertahan\n\n";
            typingEffect();

            kata = $"{playerName}, kamu akan menahan serangan {monsterType} selanjutnya dan mengisi SP milikmu";
            blockAction();
            playerSkillPoints();
            typingEffect();
            Thread.Sleep(500);
            break;
            
            case 4:
            kata = $"\n\n{playerName} memilih untuk menghindari serangan\n\n";
            typingEffect();
            evadeAction();
            kata = $"\n{playerName} akan mendapatkan tambahan 40% evasion chance\n";
            typingEffect();
            break;

            default:
            kata = "Maaf aksi yang anda pilih tidak tersedia silahkan pilih lagi";
            typingEffect();
            aksimu();
            break;
            }

            choose = 0;
        }

        void aksiMonster()
        {
            action = dice.Next(1,4); attributeMonster(); attackingPerson = monsterType; critSuccess = false; 
            evasionSuccess = false; naturalMissChance = 41; evadeAction(); Console.WriteLine(naturalMissChance);
            
            // Aksi monster
            switch (action)
            {
                case 1:
                kata = $"{monsterType} akan menyerang {playerName}";
                Thread.Sleep(700);
                normalAttack();
                if (choose == 3)
                {
                choose = 0;
                blockAction();
                playerSkillPoints();
                playerAttacked();
                Thread.Sleep(500);
                }
                else
                {
                playerAttacked();
                Thread.Sleep(500);
                }
                break;
            
                case 2:
                maxHP = fixedMonsterHP;
                healedPerson = $"{monsterType}";
                if (monsterHP < fixedMonsterHP)
                {
                    if (MP >= 20)
                    {
                    MP -= 20;
                    healAction();
                    }
                    
                    else
                    {
                        aksiMonster();
                    }
                }
                else aksiMonster();
                
                Thread.Sleep(500);
                break;
            
                case 3:
                if (monsterType != "Slime")
                {
                    kata = $"{monsterType} akan menahan seranganmu yang selanjutnya";
                    blockAction();
                    monsterSkillPoints();
                    typingEffect();
                    Thread.Sleep(500);
                }
                else
                    {aksiMonster();}
                break;
            }
        }

        void attackAction()
        {   
            Console.Clear();
            gameRound();
            playerTurn();

            kata = $"\n\nSerangan apa yang ingin kamu lakukan?\n\n1. Light Attack (Guarantee Crit, Crit DMG -55%, Evasion Chance +20%)\n2. Normal Attack (Random ATK%, CRIT DMG Normal)\n3. Heavy Attack (CRIT DMG + 35%, jika serangan meleset maka 20% dari Output DMG akan melukaimu)\n\n";
            typingEffect();
            input();

            switch(choose)
            {
                case 1:
                attackType = "Light Attack";
                kata = $"\n\n{playerName} akan menyerang dengan {attackType}\n\n";
                kata += $"\n{attackingPerson} akan mendapatkan tambahan 20% evasion chance\n";
                typingEffect();
                lightAttack();
                break;

                case 2:
                attackType = "Normal Attack";
                kata = $"\n\n{playerName} akan menyerang dengan {attackType}\n\n";
                typingEffect();
                normalAttack();
                break;

                case 3:
                attackType = "Heavy Attack";
                kata = $"\n\n{playerName} akan menyerang dengan {attackType}\n\n";;
                typingEffect();
                heavyAttack();
                playerHP = HP;
                break;

                default:
                kata = $"\n\nInput anda tidak valid\n\n";
                typingEffect();
                break;
            }

            playerSkillPoints();

            outputDmg = Math.Truncate(Math.Round(outputDmg));
            Thread.Sleep(500);
        }

        void lightAttack()
        {
            critMultiplier = 1.45; effectDuration = 2; roll = 1;
            rawDamage();
            criticalDamage();
            evasion();
            if (evasionSuccess == false)
            {
                if (critSuccess == true)
                {
                    kata = $"{critPerson} berhasil menimbulkan critical\n";
                    typingEffect();
                    
                }
                SP++;
            }           
        }

        void normalAttack()
        {
            critMultiplier = 2;
            roll = dice.Next(1,15);
            rawDamage();
            evasion();
            if (evasionSuccess == false)
            {    
                if (critSuccess == true)
                {
                    kata = $"{critPerson} berhasil menimbulkan critical\n";
                    typingEffect();
                }
                SP++;
            }
        }

        void heavyAttack()
        {
            critMultiplier = 2.35;
            roll = 14;
            miss = dice.Next(1,3);
            rawDamage();
            evasion();
            if (evasionSuccess == false)
            {
                switch (miss)
                {
                    case 1:
                    outputDmg = Math.Round(outputDmg * 0.8);
                    double heavySideEffect = Math.Truncate(Math.Round((outputDmg * 0.2)));
                    HP -= heavySideEffect;
                    SP += 2;
                    
                    kata = $"\nSerangan {attackingPerson} meleset sedikit sehingga damage berkurang 20%";
                    typingEffect();

                    kata = $"\n{attackingPerson} terluka sebanyak {heavySideEffect} nyawa karena serangannya sendiri";
                    typingEffect();

                    kata = $"\n{attackingPerson} sekarang memiliki {HP} nyawa\n";
                    typingEffect();
                    break;

                    default:
                    critChance += 50;
                    critical();
                    critChance = 0;
                    SP++;
                    break;
                }
                
                if (critSuccess == true)
                {
                    kata = $"{critPerson} berhasil menimbulkan critical\n";
                    typingEffect();
                }
            }
        }

        void healAction()
        {
            MP -= 20;
            heal = Math.Truncate(Math.Round((maxHP / 10 + (level * 2/10d)), 0));
            
            if (healedPerson == $"{playerName}")
            {
                playerHP += heal;
                if (playerHP >= fixedPlayerHP) {playerHP = fixedPlayerHP;}
                kata = $"{playerName} memulihkan {heal} nyawa dan sekarang memiliki {playerHP} nyawa\n{playerName} sekarang memiliki {MP} MP\n";
                typingEffect();
                maxHP = 0; 
                playerMP = MP; 
            }
            else
            {
                monsterHP += heal;
                if (monsterHP >= fixedMonsterHP) {monsterHP = fixedMonsterHP;}
                kata = $"{monsterType} memulihkan {heal} nyawa dan sekarang memiliki {monsterHP} nyawa\n{monsterType} sekarang memiliki {MP} MP";
                typingEffect();
                maxHP = 0;
                monsterMP = MP;
            }
        }
        
        void blockAction()
        {
                outputDmg = Math.Truncate(Math.Round(outputDmg - (outputDmg * blockReduction)));
                SP++;
        }

        void evasion()
        {
            int Comparator = 51;

            // if (AGI > DEX)
            // {
            //     AGI -= DEX;
            //     naturalMissChance = naturalMissChance + AGI / 4;
            // }
            // else
            // {
            //     DEX -= AGI;
            //     Comparator = Comparator + DEX / 4;
            // }

            if (naturalMissChance >= Comparator) naturalMissChance = Comparator - 1;
            int comparing = dice.Next(naturalMissChance, Comparator);
            Comparator--;

            if (comparing == Comparator)
            {
                evasionSuccess = true;
                outputDmg = 0;
                if (attackingPerson == playerName)
                {
                    kata = $"Namun {monsterType} berhasil menghindari serangan {playerName}\n";
                    typingEffect();
                }
                else
                {
                    kata = $"Namun {playerName} berhasil menghindari serangan {monsterType}\n";
                    typingEffect();
                }
            }
        }

        void evadeAction()
        {
            if (attackType == "Light Attack") naturalMissChance += 10;
            if (evade == true) naturalMissChance += 20; evade = false;
        }

        void special()
        {

        }

    #endregion


    #region Monster

    void monstertype()
    {
        int monster = dice.Next(1,5);

        switch (monster)
        {
            case 1:
            slime();
            break;

            case 2:
            goblin();
            break;

            case 3:
            if (slimeKingSpawn == true) slimeKing();
            else monstertype();
            break;

            case 4:
            if (goblinKingSpawn == true) goblinKing();
            else monstertype();
            break;
        }
    }

    void defeatedMonsterCheck()
    {
        switch (monsterType)
        {
            case "Slime":
            defeatedSlime++;
            
            if (defeatedSlime == 10)
            {
                slimeKingSpawn = true;
                defeatedSlime = 0;
            }
            break;
            
            case "Goblin":
            defeatedGoblin++;
            
            if (defeatedGoblin == 10)
            {
                goblinKingSpawn = true;
                defeatedGoblin = 0;
            }
            break;
        }
    }

    void slime()
    {
        int minLvl, maxLvl;
        minLvl = playerLvl;
        maxLvl = playerLvl + 5;
        monsterType = "Slime";
        
        monsterLvl = dice.Next(minLvl,maxLvl);
        fixedMonsterHP = 20;
        monsterATK = 9 + (monsterLvl * 1);
        monsterDEF = 5 + (monsterLvl * 2); 
        experienceGiven = 5;
    }

    void goblin()
    {
        int minLvl, maxLvl;
        minLvl = playerLvl + 2;
        maxLvl = playerLvl + 7;
        monsterType = "Goblin";
        
        monsterLvl = dice.Next(minLvl,maxLvl);
        fixedMonsterHP = 40;
        monsterATK = 12 + (monsterLvl * 2);
        monsterDEF = 7 + (monsterLvl * 1);
        experienceGiven = 15;
    }

    void slimeKing()
    {

    }

    void goblinKing()
    {

    }

    #endregion
    
    }

    static void Main(string[] args)
    {
        Console.Clear();
        games();
    }
}


// Next Task Alpha V 1.5.3

// Tambah monster = kobold <>= goblin, hobgoblin > kobold, orc <>= hobgoblin , giant > orc, goblin king > orc, goblin mage (different type damage)

// Tambahkan Attribute (INT dan RES)

// Perbaiki sistem level (Progress = 100%?)

// Buat aksi evade (natural miss chance + 40%) (Progress = 70%) WIP

// Tipe ending (Bad Ending, Neutral Bad Ending, Neutral Happy Ending, Happy Ending, True End, IF END (Khusus) (Flashback before story) (unexpected (demon king)) )