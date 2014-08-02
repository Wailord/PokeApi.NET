﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using LitJson;

namespace PokeAPI.NET
{
    /// <summary>
    /// Represents a Pokémon.
    /// </summary>
    public class Pokemon : PokeApiType
    {
        /// <summary>
        /// Wether it should cache pokémon data or not.
        /// </summary>
        public static bool ShouldCacheData = true;
        /// <summary>
        /// All cached pokémon.
        /// </summary>
        public static Dictionary<int, Pokemon> CachedPokemon = new Dictionary<int, Pokemon>();

        PokemonTypeFlags t = (PokemonTypeFlags)(-1);

        #region public readonly static IDictionary<string, int> IDs = new Dictionary<string, int> { [...] };
        /// <summary>
        /// All pokémon string->ID maps.
        /// </summary>
        public readonly static IDictionary<string, int> IDs = new Dictionary<string, int>
        {
            { "bulbasaur", 1 },
            { "ivysaur", 2 },
            { "venusaur", 3 },
            { "charmander", 4 },
            { "charmeleon", 5 },
            { "charizard", 6 },
            { "squirtle", 7 },
            { "wartortle", 8 },
            { "blastoise", 9 },
            { "caterpie", 10 },
            { "metapod", 11 },
            { "butterfree", 12 },
            { "weedle", 13 },
            { "kakuna", 14 },
            { "beedrill", 15 },
            { "pidgey", 16 },
            { "pidgeotto", 17 },
            { "pidgeot", 18 },
            { "rattata", 19 },
            { "raticate", 20 },
            { "spearow", 21 },
            { "fearow", 22 },
            { "ekans", 23 },
            { "arbok", 24 },
            { "pikachu", 25 },
            { "raichu", 26 },
            { "sandshrew", 27 },
            { "sandslash", 28 },
            { "nidoran f", 29 },
            { "nidoran-f", 29 },
            { "nidorina", 30 },
            { "nidoqueen", 31 },
            { "nidoran m", 32 },
            { "nidoran-m", 32 },
            { "nidorino", 33 },
            { "nidoking", 34 },
            { "clefairy", 35 },
            { "clefable", 36 },
            { "vulpix", 37 },
            { "ninetales", 38 },
            { "jigglypuff", 39 },
            { "wigglytuff", 40 },
            { "zubat", 41 },
            { "golbat", 42 },
            { "oddish", 43 },
            { "gloom", 44 },
            { "vileplume", 45 },
            { "paras", 46 },
            { "parasect", 47 },
            { "venonat", 48 },
            { "venomoth", 49 },
            { "diglett", 50 },
            { "dugtrio", 51 },
            { "meowth", 52 },
            { "persian", 53 },
            { "psyduck", 54 },
            { "golduck", 55 },
            { "mankey", 56 },
            { "primeape", 57 },
            { "growlithe", 58 },
            { "arcanine", 59 },
            { "poliwag", 60 },
            { "poliwhirl", 61 },
            { "poliwrath", 62 },
            { "abra", 63 },
            { "kadabra", 64 },
            { "alakazam", 65 },
            { "machop", 66 },
            { "machoke", 67 },
            { "machamp", 68 },
            { "bellsprout", 69 },
            { "weepinbell", 70 },
            { "victreebel", 71 },
            { "tentacool", 72 },
            { "tentacruel", 73 },
            { "geodude", 74 },
            { "graveler", 75 },
            { "golem", 76 },
            { "ponyta", 77 },
            { "rapidash", 78 },
            { "slowpoke", 79 },
            { "slowbro", 80 },
            { "magnemite", 81 },
            { "magneton", 82 },
            { "farfetchd", 83 },
            { "doduo", 84 },
            { "dodrio", 85 },
            { "seel", 86 },
            { "dewgong", 87 },
            { "grimer", 88 },
            { "muk", 89 },
            { "shellder", 90 },
            { "cloyster", 91 },
            { "gastly", 92 },
            { "haunter", 93 },
            { "gengar", 94 },
            { "onix", 95 },
            { "drowzee", 96 },
            { "hypno", 97 },
            { "krabby", 98 },
            { "kingler", 99 },
            { "voltorb", 100 },
            { "electrode", 101 },
            { "exeggcute", 102 },
            { "exeggutor", 103 },
            { "cubone", 104 },
            { "marowak", 105 },
            { "hitmonlee", 106 },
            { "hitmonchan", 107 },
            { "lickitung", 108 },
            { "koffing", 109 },
            { "weezing", 110 },
            { "rhyhorn", 111 },
            { "rhydon", 112 },
            { "chansey", 113 },
            { "tangela", 114 },
            { "kangaskhan", 115 },
            { "horsea", 116 },
            { "seadra", 117 },
            { "goldeen", 118 },
            { "seaking", 119 },
            { "staryu", 120 },
            { "starmie", 121 },
            { "mr mime", 122 },
            { "mr-mime", 122 },
            { "scyther", 123 },
            { "jynx", 124 },
            { "electabuzz", 125 },
            { "magmar", 126 },
            { "pinsir", 127 },
            { "tauros", 128 },
            { "magikarp", 129 },
            { "gyarados", 130 },
            { "lapras", 131 },
            { "ditto", 132 },
            { "eevee", 133 },
            { "vaporeon", 134 },
            { "jolteon", 135 },
            { "flareon", 136 },
            { "porygon", 137 },
            { "omanyte", 138 },
            { "omastar", 139 },
            { "kabuto", 140 },
            { "kabutops", 141 },
            { "aerodactyl", 142 },
            { "snorlax", 143 },
            { "articuno", 144 },
            { "zapdos", 145 },
            { "moltres", 146 },
            { "dratini", 147 },
            { "dragonair", 148 },
            { "dragonite", 149 },
            { "mewtwo", 150 },
            { "mew", 151 },
            { "chikorita", 152 },
            { "bayleef", 153 },
            { "meganium", 154 },
            { "cyndaquil", 155 },
            { "quilava", 156 },
            { "typhlosion", 157 },
            { "totodile", 158 },
            { "croconaw", 159 },
            { "feraligatr", 160 },
            { "sentret", 161 },
            { "furret", 162 },
            { "hoothoot", 163 },
            { "noctowl", 164 },
            { "ledyba", 165 },
            { "ledian", 166 },
            { "spinarak", 167 },
            { "ariados", 168 },
            { "crobat", 169 },
            { "chinchou", 170 },
            { "lanturn", 171 },
            { "pichu", 172 },
            { "cleffa", 173 },
            { "igglybuff", 174 },
            { "togepi", 175 },
            { "togetic", 176 },
            { "natu", 177 },
            { "xatu", 178 },
            { "mareep", 179 },
            { "flaaffy", 180 },
            { "ampharos", 181 },
            { "bellossom", 182 },
            { "marill", 183 },
            { "azumarill", 184 },
            { "sudowoodo", 185 },
            { "politoed", 186 },
            { "hoppip", 187 },
            { "skiploom", 188 },
            { "jumpluff", 189 },
            { "aipom", 190 },
            { "sunkern", 191 },
            { "sunflora", 192 },
            { "yanma", 193 },
            { "wooper", 194 },
            { "quagsire", 195 },
            { "espeon", 196 },
            { "umbreon", 197 },
            { "murkrow", 198 },
            { "slowking", 199 },
            { "misdreavus", 200 },
            { "unown", 201 },
            { "wobbuffet", 202 },
            { "girafarig", 203 },
            { "pineco", 204 },
            { "forretress", 205 },
            { "dunsparce", 206 },
            { "gligar", 207 },
            { "steelix", 208 },
            { "snubbull", 209 },
            { "granbull", 210 },
            { "qwilfish", 211 },
            { "scizor", 212 },
            { "shuckle", 213 },
            { "heracross", 214 },
            { "sneasel", 215 },
            { "teddiursa", 216 },
            { "ursaring", 217 },
            { "slugma", 218 },
            { "magcargo", 219 },
            { "swinub", 220 },
            { "piloswine", 221 },
            { "corsola", 222 },
            { "remoraid", 223 },
            { "octillery", 224 },
            { "delibird", 225 },
            { "mantine", 226 },
            { "skarmory", 227 },
            { "houndour", 228 },
            { "houndoom", 229 },
            { "kingdra", 230 },
            { "phanpy", 231 },
            { "donphan", 232 },
            { "porygon2", 233 },
            { "stantler", 234 },
            { "smeargle", 235 },
            { "tyrogue", 236 },
            { "hitmontop", 237 },
            { "smoochum", 238 },
            { "elekid", 239 },
            { "magby", 240 },
            { "miltank", 241 },
            { "blissey", 242 },
            { "raikou", 243 },
            { "entei", 244 },
            { "suicune", 245 },
            { "larvitar", 246 },
            { "pupitar", 247 },
            { "tyranitar", 248 },
            { "lugia", 249 },
            { "ho-oh", 250 },
            { "ho oh", 250 },
            { "celebi", 251 },
            { "treecko", 252 },
            { "grovyle", 253 },
            { "sceptile", 254 },
            { "torchic", 255 },
            { "combusken", 256 },
            { "blaziken", 257 },
            { "mudkip", 258 },
            { "marshtomp", 259 },
            { "swampert", 260 },
            { "poochyena", 261 },
            { "mightyena", 262 },
            { "zigzagoon", 263 },
            { "linoone", 264 },
            { "wurmple", 265 },
            { "silcoon", 266 },
            { "beautifly", 267 },
            { "cascoon", 268 },
            { "dustox", 269 },
            { "lotad", 270 },
            { "lombre", 271 },
            { "ludicolo", 272 },
            { "seedot", 273 },
            { "nuzleaf", 274 },
            { "shiftry", 275 },
            { "taillow", 276 },
            { "swellow", 277 },
            { "wingull", 278 },
            { "pelipper", 279 },
            { "ralts", 280 },
            { "kirlia", 281 },
            { "gardevoir", 282 },
            { "surskit", 283 },
            { "masquerain", 284 },
            { "shroomish", 285 },
            { "breloom", 286 },
            { "slakoth", 287 },
            { "vigoroth", 288 },
            { "slaking", 289 },
            { "nincada", 290 },
            { "ninjask", 291 },
            { "shedinja", 292 },
            { "whismur", 293 },
            { "loudred", 294 },
            { "exploud", 295 },
            { "makuhita", 296 },
            { "hariyama", 297 },
            { "azurill", 298 },
            { "nosepass", 299 },
            { "skitty", 300 },
            { "delcatty", 301 },
            { "sableye", 302 },
            { "mawile", 303 },
            { "aron", 304 },
            { "lairon", 305 },
            { "aggron", 306 },
            { "meditite", 307 },
            { "medicham", 308 },
            { "electrike", 309 },
            { "manectric", 310 },
            { "plusle", 311 },
            { "minun", 312 },
            { "volbeat", 313 },
            { "illumise", 314 },
            { "roselia", 315 },
            { "gulpin", 316 },
            { "swalot", 317 },
            { "carvanha", 318 },
            { "sharpedo", 319 },
            { "wailmer", 320 },
            { "wailord", 321 },
            { "numel", 322 },
            { "camerupt", 323 },
            { "torkoal", 324 },
            { "spoink", 325 },
            { "grumpig", 326 },
            { "spinda", 327 },
            { "trapinch", 328 },
            { "vibrava", 329 },
            { "flygon", 330 },
            { "cacnea", 331 },
            { "cacturne", 332 },
            { "swablu", 333 },
            { "altaria", 334 },
            { "zangoose", 335 },
            { "seviper", 336 },
            { "lunatone", 337 },
            { "solrock", 338 },
            { "barboach", 339 },
            { "whiscash", 340 },
            { "corphish", 341 },
            { "crawdaunt", 342 },
            { "baltoy", 343 },
            { "claydol", 344 },
            { "lileep", 345 },
            { "cradily", 346 },
            { "anorith", 347 },
            { "armaldo", 348 },
            { "feebas", 349 },
            { "milotic", 350 },
            { "castform", 351 },
            { "kecleon", 352 },
            { "shuppet", 353 },
            { "banette", 354 },
            { "duskull", 355 },
            { "dusclops", 356 },
            { "tropius", 357 },
            { "chimecho", 358 },
            { "absol", 359 },
            { "wynaut", 360 },
            { "snorunt", 361 },
            { "glalie", 362 },
            { "spheal", 363 },
            { "sealeo", 364 },
            { "walrein", 365 },
            { "clamperl", 366 },
            { "huntail", 367 },
            { "gorebyss", 368 },
            { "relicanth", 369 },
            { "luvdisc", 370 },
            { "bagon", 371 },
            { "shelgon", 372 },
            { "salamence", 373 },
            { "beldum", 374 },
            { "metang", 375 },
            { "metagross", 376 },
            { "regirock", 377 },
            { "regice", 378 },
            { "registeel", 379 },
            { "latias", 380 },
            { "latios", 381 },
            { "kyogre", 382 },
            { "groudon", 383 },
            { "rayquaza", 384 },
            { "jirachi", 385 },
            { "deoxys", 386 },
            { "turtwig", 387 },
            { "grotle", 388 },
            { "torterra", 389 },
            { "chimchar", 390 },
            { "monferno", 391 },
            { "infernape", 392 },
            { "piplup", 393 },
            { "prinplup", 394 },
            { "empoleon", 395 },
            { "starly", 396 },
            { "staravia", 397 },
            { "staraptor", 398 },
            { "bidoof", 399 },
            { "bibarel", 400 },
            { "kricketot", 401 },
            { "kricketune", 402 },
            { "shinx", 403 },
            { "luxio", 404 },
            { "luxray", 405 },
            { "budew", 406 },
            { "roserade", 407 },
            { "cranidos", 408 },
            { "rampardos", 409 },
            { "shieldon", 410 },
            { "bastiodon", 411 },
            { "burmy", 412 },
            { "wormadam", 413 },
            { "mothim", 414 },
            { "combee", 415 },
            { "vespiquen", 416 },
            { "pachirisu", 417 },
            { "buizel", 418 },
            { "floatzel", 419 },
            { "cherubi", 420 },
            { "cherrim", 421 },
            { "shellos", 422 },
            { "gastrodon", 423 },
            { "ambipom", 424 },
            { "drifloon", 425 },
            { "drifblim", 426 },
            { "buneary", 427 },
            { "lopunny", 428 },
            { "mismagius", 429 },
            { "honchkrow", 430 },
            { "glameow", 431 },
            { "purugly", 432 },
            { "chingling", 433 },
            { "stunky", 434 },
            { "skuntank", 435 },
            { "bronzor", 436 },
            { "bronzong", 437 },
            { "bonsly", 438 },
            { "mime jr", 439 },
            { "mime-jr", 439 },
            { "happiny", 440 },
            { "chatot", 441 },
            { "spiritomb", 442 },
            { "gible", 443 },
            { "gabite", 444 },
            { "garchomp", 445 },
            { "munchlax", 446 },
            { "riolu", 447 },
            { "lucario", 448 },
            { "hippopotas", 449 },
            { "hippowdon", 450 },
            { "skorupi", 451 },
            { "drapion", 452 },
            { "croagunk", 453 },
            { "toxicroak", 454 },
            { "carnivine", 455 },
            { "finneon", 456 },
            { "lumineon", 457 },
            { "mantyke", 458 },
            { "snover", 459 },
            { "abomasnow", 460 },
            { "weavile", 461 },
            { "magnezone", 462 },
            { "lickilicky", 463 },
            { "rhyperior", 464 },
            { "tangrowth", 465 },
            { "electivire", 466 },
            { "magmortar", 467 },
            { "togekiss", 468 },
            { "yanmega", 469 },
            { "leafeon", 470 },
            { "glaceon", 471 },
            { "gliscor", 472 },
            { "mamoswine", 473 },
            { "porygon z", 474 },
            { "porygon-z", 474 },
            { "gallade", 475 },
            { "probopass", 476 },
            { "dusknoir", 477 },
            { "froslass", 478 },
            { "rotom", 479 },
            { "uxie", 480 },
            { "mesprit", 481 },
            { "azelf", 482 },
            { "dialga", 483 },
            { "palkia", 484 },
            { "heatran", 485 },
            { "regigigas", 486 },
            { "giratina", 487 },
            { "cresselia", 488 },
            { "phione", 489 },
            { "manaphy", 490 },
            { "darkrai", 491 },
            { "shaymin", 492 },
            { "arceus", 493 },
            { "victini", 494 },
            { "snivy", 495 },
            { "servine", 496 },
            { "serperior", 497 },
            { "tepig", 498 },
            { "pignite", 499 },
            { "emboar", 500 },
            { "oshawott", 501 },
            { "dewott", 502 },
            { "samurott", 503 },
            { "patrat", 504 },
            { "watchog", 505 },
            { "lillipup", 506 },
            { "herdier", 507 },
            { "stoutland", 508 },
            { "purrloin", 509 },
            { "liepard", 510 },
            { "pansage", 511 },
            { "simisage", 512 },
            { "pansear", 513 },
            { "simisear", 514 },
            { "panpour", 515 },
            { "simipour", 516 },
            { "munna", 517 },
            { "musharna", 518 },
            { "pidove", 519 },
            { "tranquill", 520 },
            { "unfezant", 521 },
            { "blitzle", 522 },
            { "zebstrika", 523 },
            { "roggenrola", 524 },
            { "boldore", 525 },
            { "gigalith", 526 },
            { "woobat", 527 },
            { "swoobat", 528 },
            { "drilbur", 529 },
            { "excadrill", 530 },
            { "audino", 531 },
            { "timburr", 532 },
            { "gurdurr", 533 },
            { "conkeldurr", 534 },
            { "tympole", 535 },
            { "palpitoad", 536 },
            { "seismitoad", 537 },
            { "throh", 538 },
            { "sawk", 539 },
            { "sewaddle", 540 },
            { "swadloon", 541 },
            { "leavanny", 542 },
            { "venipede", 543 },
            { "whirlipede", 544 },
            { "scolipede", 545 },
            { "cottonee", 546 },
            { "whimsicott", 547 },
            { "petilil", 548 },
            { "lilligant", 549 },
            { "basculin", 550 },
            { "sandile", 551 },
            { "krokorok", 552 },
            { "krookodile", 553 },
            { "darumaka", 554 },
            { "darmanitan", 555 },
            { "maractus", 556 },
            { "dwebble", 557 },
            { "crustle", 558 },
            { "scraggy", 559 },
            { "scrafty", 560 },
            { "sigilyph", 561 },
            { "yamask", 562 },
            { "cofagrigus", 563 },
            { "tirtouga", 564 },
            { "carracosta", 565 },
            { "archen", 566 },
            { "archeops", 567 },
            { "trubbish", 568 },
            { "garbodor", 569 },
            { "zorua", 570 },
            { "zoroark", 571 },
            { "minccino", 572 },
            { "cinccino", 573 },
            { "gothita", 574 },
            { "gothorita", 575 },
            { "gothitelle", 576 },
            { "solosis", 577 },
            { "duosion", 578 },
            { "reuniclus", 579 },
            { "ducklett", 580 },
            { "swanna", 581 },
            { "vanillite", 582 },
            { "vanillish", 583 },
            { "vanilluxe", 584 },
            { "deerling", 585 },
            { "sawsbuck", 586 },
            { "emolga", 587 },
            { "karrablast", 588 },
            { "escavalier", 589 },
            { "foongus", 590 },
            { "amoonguss", 591 },
            { "frillish", 592 },
            { "jellicent", 593 },
            { "alomomola", 594 },
            { "joltik", 595 },
            { "galvantula", 596 },
            { "ferroseed", 597 },
            { "ferrothorn", 598 },
            { "klink", 599 },
            { "klang", 600 },
            { "klinklang", 601 },
            { "tynamo", 602 },
            { "eelektrik", 603 },
            { "eelektross", 604 },
            { "elgyem", 605 },
            { "beheeyem", 606 },
            { "litwick", 607 },
            { "lampent", 608 },
            { "chandelure", 609 },
            { "axew", 610 },
            { "fraxure", 611 },
            { "haxorus", 612 },
            { "cubchoo", 613 },
            { "beartic", 614 },
            { "cryogonal", 615 },
            { "shelmet", 616 },
            { "accelgor", 617 },
            { "stunfisk", 618 },
            { "mienfoo", 619 },
            { "mienshao", 620 },
            { "druddigon", 621 },
            { "golett", 622 },
            { "golurk", 623 },
            { "pawniard", 624 },
            { "bisharp", 625 },
            { "bouffalant", 626 },
            { "rufflet", 627 },
            { "braviary", 628 },
            { "vullaby", 629 },
            { "mandibuzz", 630 },
            { "heatmor", 631 },
            { "durant", 632 },
            { "deino", 633 },
            { "zweilous", 634 },
            { "hydreigon", 635 },
            { "larvesta", 636 },
            { "volcarona", 637 },
            { "cobalion", 638 },
            { "terrakion", 639 },
            { "virizion", 640 },
            { "tornadus", 641 },
            { "thundurus", 642 },
            { "reshiram", 643 },
            { "zekrom", 644 },
            { "landorus", 645 },
            { "kyurem", 646 },
            { "keldeo", 647 },
            { "meloetta", 648 },
            { "genesect", 649 },
            { "chespin", 650 },
            { "quilladin", 651 },
            { "chesnaught", 652 },
            { "fennekin", 653 },
            { "braixen", 654 },
            { "delphox", 655 },
            { "froakie", 656 },
            { "frogadier", 657 },
            { "greninja", 658 },
            { "bunnelby", 659 },
            { "diggersby", 660 },
            { "fletchling", 661 },
            { "fletchinder", 662 },
            { "talonflame", 663 },
            { "scatterbug", 664 },
            { "spewpa", 665 },
            { "vivillon", 666 },
            { "litleo", 667 },
            { "pyroar", 668 },
            { "flabebe", 669 },
            { "floette", 670 },
            { "florges", 671 },
            { "skiddo", 672 },
            { "gogoat", 673 },
            { "pancham", 674 },
            { "pangoro", 675 },
            { "furfrou", 676 },
            { "espurr", 677 },
            { "meowstic", 678 },
            { "honedge", 679 },
            { "doublade", 680 },
            { "aegislash", 681 },
            { "spritzee", 682 },
            { "aromatisse", 683 },
            { "swirlix", 684 },
            { "slurpuff", 685 },
            { "inkay", 686 },
            { "malamar", 687 },
            { "binacle", 688 },
            { "barbaracle", 689 },
            { "skrelp", 690 },
            { "dragalge", 691 },
            { "clauncher", 692 },
            { "clawitzer", 693 },
            { "helioptile", 694 },
            { "heliolisk", 695 },
            { "tyrunt", 696 },
            { "tyrantrum", 697 },
            { "amaura", 698 },
            { "aurorus", 699 },
            { "sylveon", 700 },
            { "hawlucha", 701 },
            { "dedenne", 702 },
            { "carbink", 703 },
            { "goomy", 704 },
            { "sliggoo", 705 },
            { "goodra", 706 },
            { "klefki", 707 },
            { "phantump", 708 },
            { "trevenant", 709 },
            { "pumpkaboo", 710 },
            { "gourgeist", 711 },
            { "bergmite", 712 },
            { "avalugg", 713 },
            { "noibat", 714 },
            { "noivern", 715 },
            { "xerneas", 716 },
            { "yveltal", 717 },
            { "zygarde", 718 }
        };
        #endregion

        /// <summary>
        /// Gets the abilities this Pokémon can have.
        /// </summary>
        public List<NameUriPair> Abilities
        {
            get;
            private set;
        } = new List<NameUriPair>();
        /// <summary>
        /// Gets the egg groups this Pokémon is in.
        /// </summary>
        public List<NameUriPair> EggGroups
        {
            get;
            private set;
        } = new List<NameUriPair>();
        /// <summary>
        /// Gets the evolutions this Pokémon can evolve into.
        /// </summary>
        public List<Evolution> Evolutions
        {
            get;
            private set;
        } = new List<Evolution>();
        /// <summary>
        /// Gets the moves this Pokémon can learn.
        /// </summary>
        public List<Tuple<string, NameUriPair>> Moves
        {
            get;
            private set;
        } = new List<Tuple<string, NameUriPair>>();
        /// <summary>
        /// Gets the types this Pokemon is.
        /// </summary>
        public List<NameUriPair> Types
        {
            get;
            private set;
        } = new List<NameUriPair>();
        /// <summary>
        /// Gets the descriptions of the Pokémon.
        /// </summary>
        public List<NameUriPair> Descriptions
        {
            get;
            private set;
        } = new List<NameUriPair>();

        /// <summary>
        /// Gets an entry of the Abilities list as an Ability.
        /// </summary>
        /// <param name="index">The index of the entry</param>
        /// <returns>The entry of the Abilities list as a Ability</returns>
        public Ability RefAbility(int index)
        {
            return Ability.GetInstance(Abilities[index].Name);
        }
        /// <summary>
        /// Gets an entry of the EggGroups list as an EggGroup.
        /// </summary>
        /// <param name="index">The index of the entry</param>
        /// <returns>The entry of the EggGroups list as an EggGroup</returns>
        public EggGroup RefEggGroup(int index)
        {
            return EggGroup.GetInstance(EggGroups[index].Name);
        }
        /// <summary>
        /// Gets an entry of the Moves list as a Move.
        /// </summary>
        /// <param name="index">The index of the entry</param>
        /// <returns>The entry of the Moves list as a Move</returns>
        public Move RefMove(int index)
        {
            return Move.GetInstance(Moves[index].Item2.Name);
        }
        /// <summary>
        /// Gets an entry of the Types list as a PokemonType.
        /// </summary>
        /// <param name="index">The index of the entry</param>
        /// <returns>The entry of the Types list as a PokemonType</returns>
        public PokemonType RefType(int index)
        {
            return PokemonType.GetInstance(Types[index].Name);
        }
        /// <summary>
        /// Gets an entry of the Descriptions list as a Description.
        /// </summary>
        /// <param name="index">The index of the entry.</param>
        /// <returns>The entry of the Descriptions list as a Description.</returns>
        public Description RefDescription(int index)
        {
            NameUriPair nup = Descriptions[index];
            string[] split = nup.ResourceUri.ToString().Split(new char[] { '/' }, StringSplitOptions.RemoveEmptyEntries);
            int num = Int32.Parse(split[split.Length - 1]);
            return Description.GetInstance(num);//Description.GetInstance
        }

        /// <summary>
        /// The species of this Pokemon instance
        /// </summary>
        public string Species
        {
            get;
            private set;
        } = String.Empty;
        /// <summary>
        /// The growth rate of this Pokemon instance
        /// </summary>
        public string GrowthRate
        {
            get;
            private set;
        } = String.Empty;

        /// <summary>
        /// The hit points of this Pokemon instance
        /// </summary>
        public int HP
        {
            get;
            private set;
        }
        /// <summary>
        /// The base attack of this Pokemon instance
        /// </summary>
        public int Attack
        {
            get;
            private set;
        }
        /// <summary>
        /// The base defense of this Pokemon instance
        /// </summary>
        public int Defense
        {
            get;
            private set;
        }
        /// <summary>
        /// This Pokemon instance's catch rate
        /// </summary>
        public int CatchRate
        {
            get;
            private set;
        }
        /// <summary>
        /// The base special attack of this Pokemon instance
        /// </summary>
        public int SpecialAttack
        {
            get;
            private set;
        }
        /// <summary>
        /// The base special defense of this Pokemon instance
        /// </summary>
        public int SpecialDefense
        {
            get;
            private set;
        }
        /// <summary>
        /// The base speed of this Pokemon instance
        /// </summary>
        public int Speed
        {
            get;
            private set;
        }
        /// <summary>
        /// The number of egg cycles needed
        /// </summary>
        public int EggCycles
        {
            get;
            private set;
        }
        /// <summary>
        /// The height of this Pokemon instance
        /// </summary>
        public int Height
        {
            get;
            private set;
        }
        /// <summary>
        /// The weight of this Pokemon instance
        /// </summary>
        public int Weight
        {
            get;
            private set;
        }
        /// <summary>
        /// The base happiness of this Pokemon instance
        /// </summary>
        public int BaseHappiness
        {
            get;
            private set;
        }

        /// <summary>
        /// The base effort value yield for this Pokemon instance
        /// </summary>
        public EvYield EvYield
        {
            get;
            private set;
        }
        /// <summary>
        /// The base experience yield for this Pokemon instance
        /// </summary>
        public int? ExpYield
        {
            get;
            private set;
        }

        /// <summary>
        /// The types this Pokemon instance is as a flags field
        /// </summary>
        public PokemonTypeFlags Type
        {
            get
            {
                if ((int)t == -1)
                {
                    t = 0;

                    foreach (NameUriPair pair in Types)
                        if (Enum.TryParse(pair.Name, true, out PokemonTypeFlags pt))
                            t |= pt;

                    return t;
                }

                return t;
            }
        }

        /// <summary>
        /// Gets the male/female ratio of the Pokémon.
        /// </summary>
        public Tuple<double, double> MaleFemaleRatio
        {
            get;
            private set;
        } = new Tuple<double, double>(0d, 0d);

        /// <summary>
        /// Creates a new instance from a JSON object
        /// </summary>
        /// <param name="source">The JSON object where to create the new instance from</param>
        protected override void Create(JsonData source)
        {
            ID = (int)source["national_id"];

            foreach (JsonData data in source["abilities"])
                Abilities.Add(ParseNameUriPair(data));
            foreach (JsonData data in source["egg_groups"])
                EggGroups.Add(ParseNameUriPair(data));

            if (source.Keys.Contains("evolutions"))
                for (int i = 0; i < source["evolutions"].Count; i++)
                {
                    JsonData evolution = source["evolutions"][i];
                    Evolution p = new Evolution();
                    Create(evolution, p);
                    Evolutions.Add(p);
                }

            foreach (JsonData data in source["moves"])
                Moves.Add(new Tuple<string, NameUriPair>(data["learn_type"].ToString(), ParseNameUriPair(data)));
            foreach (JsonData data in source["types"])
                Types.Add(ParseNameUriPair(data));

            CatchRate = (int)source["catch_rate"];
            Species = source["species"].ToString();
            HP = (int)source["hp"];
            Attack = (int)source["attack"];
            Defense = (int)source["defense"];
            SpecialAttack = (int)source["sp_atk"];
            SpecialDefense = (int)source["sp_def"];
            Speed = (int)source["speed"];
            EggCycles = (int)source["egg_cycles"];
            EvYield = EvYield.Parse(source);
            ExpYield = source.AsNullInt("exp");
            GrowthRate = source["growth_rate"].ToString();
            Height = source.AsInt("height");
            Weight = source.AsInt("weight");
            BaseHappiness = (int)source["happiness"];

            foreach (JsonData data in source["descriptions"])
                Descriptions.Add(ParseNameUriPair(data));

            MaleFemaleRatio = String.IsNullOrEmpty(source["male_female_ratio"].ToString())
                ? null
                : MaleFemaleRatio = new Tuple<double, double>
            (
                Convert.ToDouble(source["male_female_ratio"].ToString().Split('/')[0], CultureInfo.InvariantCulture) / 100d,
                Convert.ToDouble(source["male_female_ratio"].ToString().Split('/')[1], CultureInfo.InvariantCulture) / 100d
            );
        }

        /// <summary>
        /// Creates an instance of a Pokemon with the given name
        /// </summary>
        /// <param name="name">The name of the Pokemon to instantiate</param>
        /// <returns>The created instance of the Pokemon</returns>
        public static Pokemon GetInstance(string name)
        {
            return GetInstance(IDs[name.ToLower()]);
        }
        /// <summary>
        /// Creates an instance of a Pokemon with the given ID
        /// </summary>
        /// <param name="id">The ID of the Pokemon to instantiate</param>
        /// <returns>The created instance of the Pokemon</returns>
        public static Pokemon GetInstance(int id)
        {
            if (CachedPokemon.ContainsKey(id))
                return CachedPokemon[id];

            Pokemon p = new Pokemon();
            Create(DataFetcher.GetPokemon(id), p);

            if (ShouldCacheData)
                CachedPokemon.Add(id, p);

            return p;
        }
    }
}
