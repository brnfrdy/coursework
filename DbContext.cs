﻿using coursework.GameAccounts;
using coursework.Games;

namespace coursework;

public class DbContext
{
    public List<Game> Games { get; set; }
    public List<GameAccount> Accounts { get; set; }

    public DbContext()
    {
        Accounts = new List<GameAccount>();
        Games = new List<Game>();
    }
}
